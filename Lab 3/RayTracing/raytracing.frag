#version 430

out vec4 FragColor;
in vec3 glPosition;

uniform vec3 campos;

#define EPSILON 0.001
#define BIG 1000000.0
const int DIFFUSE = 1;
const int REFLECTION = 2;
const int REFRACTION = 3;
const int MAX_STACK_SIZE = 10;
const int MAX_TRACE_DEPTH = 5;

const int DIFFUSE_REFLECTION = 1;
const int MIRROR_REFLECTION = 2;

const int MATERIALS_SIZE = 8;
const int TRIANGLES_SIZE = 12;
const int SPHERES_SIZE = 2;

// ---------------
// DATA STRUCTURES
// ---------------

struct SSphere
{    
    vec3 Center;
	float Radius;
	int MaterialIdx;
}; 

struct STriangle
{
    vec3 v1;
    vec3 v2;
    vec3 v3;
    int MaterialIdx;
};

struct SCamera
{
    vec3 Position;
    vec3 View;
    vec3 Up;
    vec3 Side;
    vec2 Scale;
};
    
struct SRay
{
    vec3 Origin;
    vec3 Direction;
};

struct SIntersection 
{     
    float Time;    
	vec3 Point;    
	vec3 Normal;   
	vec3 Color; 
	vec4 LightCoeffs;
	float ReflectionCoef;     
	float RefractionCoef;     
	int MaterialType;
};

struct SMaterial
{
    //diffuse color
    vec3 Color;
    // ambient, diffuse and specular coeffs
    vec4 LightCoeffs;
    // 0 - non-reflection, 1 - mirror
    float ReflectionCoef;
    float RefractionCoef;
    int MaterialType;
};

struct SLight
{
    vec3 Position;
};

struct STracingRay
{
    SRay ray;
    float contribution;
    int depth;
};

struct SCube 
{
	STriangle bounds[12];
	int MaterialIdx;
};

struct STetrahedron 
{
    vec3 v1;
    vec3 v2;
    vec3 v3;
    vec3 v4;
    int MaterialIdx;
};

// ----------------
// GLOBAL VARIABLES
// ----------------

STriangle triangles[TRIANGLES_SIZE];
SSphere spheres[SPHERES_SIZE];
SMaterial materials[MATERIALS_SIZE];
SCube cube;
const vec3 Unit = vec3 ( 1.0, 1.0, 1.0 );
SCamera uCamera;
SLight uLight;
STracingRay stack[MAX_STACK_SIZE];
int stackSize = 0;
STetrahedron tetrahedron;
uniform float u_reflectionCoef;

// --------------------
// FUNCTION DEFINITIONS
// --------------------

void initializeCube(out SCube cube, vec3 minVertex, vec3 maxVertex, int materialIdx)
{
    vec3 vertices[8] = {
        minVertex, 
        vec3(maxVertex.x, minVertex.y, minVertex.z),
        vec3(minVertex.x, maxVertex.y, minVertex.z),
        vec3(maxVertex.x, maxVertex.y, minVertex.z),
        vec3(minVertex.x, minVertex.y, maxVertex.z),
        vec3(maxVertex.x, minVertex.y, maxVertex.z),
        vec3(minVertex.x, maxVertex.y, maxVertex.z),
        maxVertex
    };

    cube.bounds[0].v1 = vertices[0];   cube.bounds[0].v2 = vertices[1];   cube.bounds[0].v3 = vertices[2];
    cube.bounds[1].v1 = vertices[1];   cube.bounds[1].v2 = vertices[3];   cube.bounds[1].v3 = vertices[2]; 
    cube.bounds[2].v1 = vertices[4];   cube.bounds[2].v2 = vertices[5];   cube.bounds[2].v3 = vertices[6];
    cube.bounds[3].v1 = vertices[5];   cube.bounds[3].v2 = vertices[7];   cube.bounds[3].v3 = vertices[6];
    cube.bounds[4].v1 = vertices[0];   cube.bounds[4].v2 = vertices[4];   cube.bounds[4].v3 = vertices[2];
    cube.bounds[5].v1 = vertices[4];   cube.bounds[5].v2 = vertices[6];   cube.bounds[5].v3 = vertices[2];
    cube.bounds[6].v1 = vertices[1];   cube.bounds[6].v2 = vertices[5];   cube.bounds[6].v3 = vertices[3];
    cube.bounds[7].v1 = vertices[5];   cube.bounds[7].v2 = vertices[7];   cube.bounds[7].v3 = vertices[3];
    cube.bounds[8].v1 = vertices[0];   cube.bounds[8].v2 = vertices[1];   cube.bounds[8].v3 = vertices[4]; 
    cube.bounds[9].v1 = vertices[1];   cube.bounds[9].v2 = vertices[5];   cube.bounds[9].v3 = vertices[4]; 
    cube.bounds[10].v1 = vertices[2];  cube.bounds[10].v2 = vertices[3];  cube.bounds[10].v3 = vertices[6]; 
    cube.bounds[11].v1 = vertices[3];  cube.bounds[11].v2 = vertices[7];  cube.bounds[11].v3 = vertices[6];

    // Assign material index to all triangles and the cube
    for (int i = 0; i < 12; ++i) 
    {
        cube.bounds[i].MaterialIdx = materialIdx;
    }
    cube.MaterialIdx = materialIdx;
}


bool pushRay(STracingRay secondaryRay)
{
	if(stackSize < MAX_STACK_SIZE - 1 && secondaryRay.depth < MAX_TRACE_DEPTH)
	{
		stack[stackSize] = secondaryRay;
		stackSize++;
		return true;
	}
	return false;
}

bool isEmpty()
{
	if(stackSize < 0)
		return true;
	return false;
}

STracingRay popRay()
{
	stackSize--;
	return stack[stackSize];	
}

void initializeDefaultScene (out STriangle triangles[TRIANGLES_SIZE], out SSphere spheres[SPHERES_SIZE])
{	
	// RIGHT UPPER
	triangles[4].v3 = vec3(5.0, -5.0, 5.0); 
	triangles[4].v2 = vec3(5.0, 5.0, 5.0); 
	triangles[4].v1 = vec3(5.0, 5.0, -8.0); 
	triangles[4].MaterialIdx = 0; 
 
	// RIGHT LOWER
    triangles[5].v3 = vec3(5.0, 5.0,-8.0);
	triangles[5].v2 = vec3(5.0, -5.0, -8.0);
	triangles[5].v1 = vec3(5.0, -5.0, 5.0); 
	triangles[5].MaterialIdx = 0;

	// FRONT LOWER
	triangles[2].v1 = vec3(-5.0, 5.0, 5.0); 
	triangles[2].v2 = vec3(-5.0, -5.0, 5.0); 
	triangles[2].v3 = vec3(5.0, -5.0, 5.0); 
	triangles[2].MaterialIdx = 1; 
 
	// FRONT UPPER
    triangles[3].v1 = vec3(5.0,-5.0, 5.0);
	triangles[3].v2 = vec3(5.0, 5.0, 5.0);
	triangles[3].v3 = vec3(-5.0, 5.0, 5.0); 
	triangles[3].MaterialIdx = 1;
	
	// LEFT UPPER
    triangles[0].v1 = vec3(-5.0,-5.0,-8.0); 
	triangles[0].v2 = vec3(-5.0, 5.0, 5.0); 
	triangles[0].v3 = vec3(-5.0, 5.0,-8.0); 
	triangles[0].MaterialIdx = 2; 
 
	// LEFT LOWER 
    triangles[1].v1 = vec3(-5.0,-5.0,-8.0);
	triangles[1].v2 = vec3(-5.0,-5.0, 5.0);
	triangles[1].v3 = vec3(-5.0, 5.0, 5.0); 
	triangles[1].MaterialIdx = 2;
	
	// TOP LEFT
	triangles[6].v3 = vec3(-5.0, 5.0, 5.0); 
	triangles[6].v2 = vec3(-5.0, 5.0, -8.0); 
	triangles[6].v1 = vec3(5.0, 5.0, -8.0); 
	triangles[6].MaterialIdx = 3; 
 
	// TOP RIGHT
    triangles[7].v3 = vec3(5.0, 5.0, -8.0); 
	triangles[7].v2 = vec3(5.0, 5.0, 5.0); 
	triangles[7].v1 = vec3(-5.0, 5.0, 5.0); 
	triangles[7].MaterialIdx = 3;
 
	// BOTTOM LEFT
    triangles[8].v1 = vec3(-5.0, -5.0, 5.0);
	triangles[8].v2 = vec3(-5.0, -5.0, -8.0);
	triangles[8].v3 = vec3(5.0, -5.0, -8.0); 
	triangles[8].MaterialIdx = 4;
	
	// BOTTOM RIGHT
	triangles[9].v1 = vec3(5.0,-5.0,-8.0);
	triangles[9].v2 = vec3(5.0, -5.0, 5.0);
	triangles[9].v3 = vec3(-5.0, -5.0, 5.0); 
	triangles[9].MaterialIdx = 4;
	
	// BACK RIGHT
	triangles[10].v3 = vec3(-5.0, -5.0, -8.0);
	triangles[10].v2 = vec3(5.0, -5.0, -8.0);
	triangles[10].v1 = vec3(5.0, 5.0, -8.0); 
	triangles[10].MaterialIdx = 5;
	
	// BACK LEFT
	triangles[11].v3 = vec3(5.0, 5.0,-8.0);
	triangles[11].v2 = vec3(-5.0, 5.0, -8.0);
	triangles[11].v1 = vec3(-5.0, -5.0, -8.0); 
	triangles[11].MaterialIdx = 5;
	
	spheres[0].Center = vec3(2.0,0.0,2.0);  
	spheres[0].Radius = 1.0;  
	spheres[0].MaterialIdx = 7; 
 
    spheres[1].Center = vec3(-2.0,-1.0,1.0);  
	spheres[1].Radius = 1.5;  
	spheres[1].MaterialIdx = 6;

	initializeCube(cube, vec3(1.0, -3.0, 0.0), vec3(2.0, -2.0, 1.0), 7); 

	tetrahedron.v4 = vec3(-1.0f, -2.0f, 2.0f);
    tetrahedron.v2 = vec3(0.0f, -2.0f, 0.0f);
    tetrahedron.v3 = vec3(1.0f, -2.0f, 2.0f);
    tetrahedron.v1 = vec3(0.0f, -0.5f, 1.0f);
    tetrahedron.MaterialIdx = 6;
}

void initializeDefaultLightMaterials(out SLight light, out SMaterial materials[8]) 
{
    light.Position = vec3(2.0, 2.0, -1.0f); 
 
    vec4 lightCoefs = vec4(0.5,0.9,0.0,512.0);    
	materials[0].Color = vec3(0.0, 1.0, 0.0);   
	materials[0].LightCoeffs = vec4(lightCoefs);
	materials[0].ReflectionCoef = 0.5;   
	materials[0].RefractionCoef = 1.0;  
	materials[0].MaterialType = DIFFUSE_REFLECTION;  
 
    materials[1].Color = vec3(0.0, 0.0, 1.0);  
	materials[1].LightCoeffs = vec4(lightCoefs); 
    materials[1].ReflectionCoef = 0.5;  
	materials[1].RefractionCoef = 1.0;  
	materials[1].MaterialType = DIFFUSE_REFLECTION;
	
	materials[2].Color = vec3(1.0, 0.0, 0.0);  
	materials[2].LightCoeffs = vec4(lightCoefs); 
    materials[2].ReflectionCoef = 0.5;  
	materials[2].RefractionCoef = 1.0;  
	materials[2].MaterialType = DIFFUSE_REFLECTION;
	
	materials[3].Color = vec3(1.0, 1.0, 1.0);  
	materials[3].LightCoeffs = vec4(lightCoefs); 
    materials[3].ReflectionCoef = 0.5;  
	materials[3].RefractionCoef = 1.0;  
	materials[3].MaterialType = DIFFUSE_REFLECTION;
	
	materials[4].Color = vec3(1.0, 1.0, 1.0);  
	materials[4].LightCoeffs = vec4(lightCoefs); 
    materials[4].ReflectionCoef = 0.4;  
	materials[4].RefractionCoef = 1.0;  
	materials[4].MaterialType = DIFFUSE_REFLECTION;
	
	materials[5].Color = vec3(1.0, 1.0, 1.0);  
	materials[5].LightCoeffs = vec4(lightCoefs); 
    materials[5].ReflectionCoef = 0.5;  
	materials[5].RefractionCoef = 1.0;  
	materials[5].MaterialType = DIFFUSE_REFLECTION;
	
	materials[6].Color = vec3(1.0, 1.0, 1.0);  
	materials[6].LightCoeffs = vec4(lightCoefs); 
    materials[6].ReflectionCoef = 0.6;  
	materials[6].RefractionCoef = 0.6;
	materials[6].MaterialType = MIRROR_REFLECTION;

	materials[7].Color = vec3(1.0, 0.2, 1.0);
	materials[7].LightCoeffs = vec4(lightCoefs); 
    materials[7].ReflectionCoef = 0.5;  
	materials[7].RefractionCoef = 1.3;  
	materials[7].MaterialType = REFRACTION;
}

SRay GenerateRay ( SCamera uCamera )
{  
    vec2 coords = glPosition.xy * uCamera.Scale;
	vec3 direction = uCamera.View + uCamera.Side * coords.x + uCamera.Up * coords.y;
	return SRay ( uCamera.Position, normalize(direction) );
}

SCamera initializeDefaultCamera()
{
    //** CAMERA **//
    SCamera camera;
    camera.Position = vec3(0.0, 0.0, -4.0);
    camera.View = vec3(0.0, 0.0, 1.0);
    camera.Up = vec3(0.0, 1.0, 0.0);
    camera.Side = vec3(1.0, 0.0, 0.0);
    camera.Scale = vec2(1.0);
    return camera;
}

vec3 Phong ( SIntersection intersect, SLight currLight, float shadowing) 
{
    vec3 light = normalize ( currLight.Position - intersect.Point ); 
    float diffuse = max(dot(light, intersect.Normal), 0.0);   
	vec3 view = normalize(uCamera.Position - intersect.Point);  
	vec3 reflected= reflect( -view, intersect.Normal );   
	float specular = pow(max(dot(reflected, light), 0.0), intersect.LightCoeffs.w);    
	return intersect.LightCoeffs.x * intersect.Color + 
	       intersect.LightCoeffs.y * diffuse * intersect.Color * shadowing + 
		   intersect.LightCoeffs.z * specular * Unit;
} 

bool IntersectSphere ( SSphere sphere, SRay ray, float start, float final, out float time )
{     
    ray.Origin -= sphere.Center;  
	float A = dot ( ray.Direction, ray.Direction );  
	float B = dot ( ray.Direction, ray.Origin );   
	float C = dot ( ray.Origin, ray.Origin ) - sphere.Radius * sphere.Radius;  
	float D = B * B - A * C; 
    if ( D > 0.0 )  
	{
    	D = sqrt ( D );
		float t1 = ( -B - D ) / A;   
		float t2 = ( -B + D ) / A;      
		if(t1 < 0 && t2 < 0)    return false;    
        if(min(t1, t2) < 0)   
		{            
    		time = max(t1,t2);      
			return true;      
		}  
		time = min(t1, t2);    
		return true;  
	}  
	return false; 
}

bool IntersectTriangle (SRay ray, vec3 v1, vec3 v2, vec3 v3, out float time ) 
{
    time = -1; 
	vec3 A = v2 - v1; 
	vec3 B = v3 - v1; 	
	vec3 N = cross(A, B);
	float NdotRayDirection = dot(N, ray.Direction); 
	if (abs(NdotRayDirection) < 0.001)   return false; 
	float d = dot(N, v1);
	float t = -(dot(N, ray.Origin) - d) / NdotRayDirection; 
	if (t < 0)   return false; 
	vec3 P = ray.Origin + t * ray.Direction;
	vec3 C;
	vec3 edge1 = v2 - v1; 
	vec3 VP1 = P - v1; 
	C = cross(edge1, VP1); 
	if (dot(N, C) < 0)  return false;
	vec3 edge2 = v3 - v2; 
	vec3 VP2 = P - v2; 
	C = cross(edge2, VP2); 
	if (dot(N, C) < 0)   return false;
	vec3 edge3 = v1 - v3; 
	vec3 VP3 = P - v3; 
	C = cross(edge3, VP3); 
	if (dot(N, C) < 0)   return false;
	time = t; 
	return true; 
}

bool Raytrace ( SRay ray, float start, float final, inout SIntersection intersect ) 
{ 
    bool result = false; 
	float test = start; 
	intersect.Time = final; 
	
	for(int i = 0; i < 12; i++) 
	{
		// RAYTRACE TRIANGLES
	    STriangle triangle = triangles[i]; 
	    if(IntersectTriangle(ray, triangle.v1, triangle.v2, triangle.v3, test) && test < intersect.Time)
	    {        
    	    intersect.Time = test;  
			intersect.Point = ray.Origin + ray.Direction * test;  
			intersect.Normal =               
				normalize(cross(triangle.v1 - triangle.v2, triangle.v3 - triangle.v2));
			SMaterial mat = materials[triangle.MaterialIdx];
			intersect.Color = mat.Color;    
			intersect.LightCoeffs = mat.LightCoeffs;
			intersect.ReflectionCoef = mat.ReflectionCoef;       
			intersect.RefractionCoef = mat.RefractionCoef;       
			intersect.MaterialType = mat.MaterialType;       
			result = true;   
		} 
	}
	
	// RAYTRACE SPHERE
	for(int i = 0; i < 2; i++) 
	{   
	    SSphere sphere = spheres[i];
		if( IntersectSphere (sphere, ray, start, final, test ) && test < intersect.Time )  
		{       
    		intersect.Time = test;    
			intersect.Point = ray.Origin + ray.Direction * test;      
			intersect.Normal = normalize ( intersect.Point - sphere.Center );
			SMaterial mat = materials[sphere.MaterialIdx];
			intersect.Color = mat.Color;        
			intersect.LightCoeffs = mat.LightCoeffs;
			intersect.ReflectionCoef = mat.ReflectionCoef;   
			intersect.RefractionCoef = mat.RefractionCoef;       
			intersect.MaterialType =   mat.MaterialType;  
			result = true;    
	    } 
	}

	// RAYTRACE CUBE
	for(int i = 0; i < 12; i++) 
	{
	    STriangle triangle = cube.bounds[i]; 
	    if(IntersectTriangle(ray, triangle.v1, triangle.v2, triangle.v3, test) && test < intersect.Time)
	    {        
    	    intersect.Time = test;  
			intersect.Point = ray.Origin + ray.Direction * test;  
			intersect.Normal =               
				normalize(cross(triangle.v1 - triangle.v2, triangle.v3 - triangle.v2));
			SMaterial mat = materials[triangle.MaterialIdx];
			intersect.Color = vec3(1.0, 0.2, 1.0);    
			intersect.LightCoeffs = mat.LightCoeffs;
			intersect.ReflectionCoef = mat.ReflectionCoef;       
			intersect.RefractionCoef = mat.RefractionCoef;       
			intersect.MaterialType = mat.MaterialType;       
			result = true;   
		} 
	}

	STriangle faces[4] = {
        {tetrahedron.v1, tetrahedron.v2, tetrahedron.v3, tetrahedron.MaterialIdx},
        {tetrahedron.v1, tetrahedron.v4, tetrahedron.v2, tetrahedron.MaterialIdx},
        {tetrahedron.v2, tetrahedron.v4, tetrahedron.v3, tetrahedron.MaterialIdx},
        {tetrahedron.v3, tetrahedron.v4, tetrahedron.v1, tetrahedron.MaterialIdx}
    };

    for (int i = 0; i < 4; ++i) 
    {
        if (IntersectTriangle(ray, faces[i].v1, faces[i].v2, faces[i].v3, test) && test < intersect.Time) 
        {
            intersect.Time = test;
            intersect.Point = ray.Origin + ray.Direction * test;
            intersect.Normal = normalize(cross(faces[i].v1 - faces[i].v2, faces[i].v3 - faces[i].v2));
            SMaterial mat = materials[faces[i].MaterialIdx];
            intersect.Color = mat.Color;
            intersect.LightCoeffs = mat.LightCoeffs;
            intersect.ReflectionCoef = mat.ReflectionCoef;
            intersect.RefractionCoef = mat.RefractionCoef;
            intersect.MaterialType = mat.MaterialType;
            result = true;
        }
    }

	return result;
}

float Shadow(SLight currLight, SIntersection intersect) 
{     
    float shadowing = 1.0;  
	vec3 direction = normalize(currLight.Position - intersect.Point);   
	float distanceLight = distance(currLight.Position, intersect.Point);  
	SRay shadowRay = SRay(intersect.Point + direction * 0.001, direction);
	SIntersection shadowIntersect;     
	shadowIntersect.Time = 1000000.0;      
	if(Raytrace(shadowRay, 0, distanceLight, shadowIntersect))  
	{   
    	shadowing = 0.0;     
	}
	return shadowing; 
}

float fresnel(vec3 incident, vec3 normal, float eta1, float eta2) {
    float cosi = clamp(dot(incident, normal), -1.0, 1.0);
    float etai = eta1, etat = eta2;
    if (cosi > 0.0)
	{
		float tmp = etat;
		etat = etai;
		etai = tmp;
	}
    float sint = etai / etat * sqrt(max(0.0, 1.0 - cosi*cosi));
    if (sint >= 1.0) { return 1.0; } // Total internal reflection
    else {
        float cost = sqrt(max(0.0, 1.0 - sint*sint));
        cosi = abs(cosi);
        float Rs = ((etat * cosi) - (etai * cost)) / ((etat * cosi) + (etai * cost));
        float Rp = ((etai * cosi) - (etat * cost)) / ((etai * cosi) + (etat * cost));
        return (Rs * Rs + Rp * Rp) / 2.0;
    }
}

void main ( void )
{
    float start = 0;   
	float final = 1000000.0;
	
	uCamera = initializeDefaultCamera();
	SRay ray = GenerateRay( uCamera);
	SIntersection intersect;        
	intersect.Time = 1000000.0;    
	vec3 resultColor = vec3(0,0,0);
	initializeDefaultLightMaterials(uLight, materials);
    initializeDefaultScene(triangles, spheres);	
	STracingRay trRay = STracingRay(ray, 1, 0); 
	pushRay(trRay); 
	while(!isEmpty()) 
	{     
	    STracingRay trRay = popRay();     
		ray = trRay.ray;    
		SIntersection intersect;  
		intersect.Time = 1000000.0;   
		start = 0;     
		final = 1000000.0;    
		if (Raytrace(ray, start, final, intersect))
		{   
    		switch(intersect.MaterialType){
    			case DIFFUSE_REFLECTION:         
				{  
    				float shadowing = Shadow(uLight, intersect);   
					resultColor += trRay.contribution * Phong ( intersect, uLight, shadowing );   
					break;       
				}  
				case MIRROR_REFLECTION: 
				{ 
    				if(intersect.ReflectionCoef < 1)   
					{              
					    float contribution = trRay.contribution * (1 - intersect.ReflectionCoef);     
					    float shadowing = Shadow(uLight, intersect);              
					    resultColor +=  contribution * Phong(intersect, uLight, shadowing);    
				    }  
				    vec3 reflectDirection = reflect(ray.Direction, intersect.Normal);
				    float contribution = trRay.contribution * intersect.ReflectionCoef;  
				    STracingRay reflectRay = STracingRay( SRay(intersect.Point + reflectDirection * 0.001, reflectDirection), contribution, trRay.depth + 1);    
				    pushRay(reflectRay);  
				    break;  
			    }
				case REFRACTION:
				{
					float eta = 1.0;
					float eta_object = 1.5;
					vec3 N = intersect.Normal;
					float cosi = clamp(dot(ray.Direction, N), -1.0, 1.0);
					float cost2;
    
					if (cosi < 0.0) 
					{ 
						cosi = -cosi; 
					} 
					else 
					{
						float tmp = eta;
						eta = eta_object;
						eta_object = tmp;
						N = -N; 
					}
    
					float eta_ratio = eta / eta_object;
					float k = 1.0 - eta_ratio * eta_ratio * (1.0 - cosi * cosi);
    
					// Total internal reflection
					if (k < 0.0) 
					{
						vec3 reflectDir = reflect(ray.Direction, N);
						float contribution = trRay.contribution * intersect.ReflectionCoef;
						STracingRay reflectRay = STracingRay(SRay(intersect.Point + reflectDir * 0.001, reflectDir),
															 contribution, trRay.depth + 1);
						pushRay(reflectRay);
					} 
					else 
					{
						cost2 = sqrt(k);
						vec3 refractDir = eta_ratio * ray.Direction + (eta_ratio * cosi - cost2) * N;
						float contribution = trRay.contribution * intersect.RefractionCoef;
						float fresnelCoeff = fresnel(ray.Direction, N, eta, eta_object);
        
						// Refraction ray
						STracingRay refractRay = STracingRay(SRay(intersect.Point + refractDir * 0.001, refractDir),
																  contribution * (1.0 - fresnelCoeff), trRay.depth + 1);
						pushRay(refractRay);
        
						// Reflection ray (Fresnel)
						vec3 reflectDir = reflect(ray.Direction, N);
						STracingRay reflectRay = STracingRay(SRay(intersect.Point + reflectDir * 0.001, reflectDir),
															 contribution * fresnelCoeff, trRay.depth + 1);
						pushRay(reflectRay);
					}
					break;
				}
			}  
		}
	}
    FragColor = vec4 ( resultColor, 1.0 );
}