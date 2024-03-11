namespace Lab_1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отменитьВсеФильтрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.назадToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фильтрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.точечныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.инверсияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.серыеТонаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сепияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.яркостьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.растяжениеГистограммыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.серыйМирToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.идеальныйОтражательToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.коррекцияСОпорнымЦветомToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.перемещениеИзображенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поворотИзображенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.волныToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.волны2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.стеклоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.матричныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.размытиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.размытиеГауссToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.медианныйФильтрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фильтрСобеляToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тиснениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.резкостьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.размытиеВДвиженииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.операторЩарраToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.операторПриToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.светящиесяКраяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.морфологияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.эрозияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.расширениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topHatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blackHatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gradToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(0, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(723, 371);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.фильтрыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(723, 27);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.отменитьВсеФильтрыToolStripMenuItem,
            this.назадToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(61, 25);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(266, 30);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(266, 30);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // отменитьВсеФильтрыToolStripMenuItem
            // 
            this.отменитьВсеФильтрыToolStripMenuItem.Name = "отменитьВсеФильтрыToolStripMenuItem";
            this.отменитьВсеФильтрыToolStripMenuItem.Size = new System.Drawing.Size(266, 30);
            this.отменитьВсеФильтрыToolStripMenuItem.Text = "Отменить все фильтры";
            this.отменитьВсеФильтрыToolStripMenuItem.Click += new System.EventHandler(this.отменитьВсеФильтрыToolStripMenuItem_Click);
            // 
            // назадToolStripMenuItem
            // 
            this.назадToolStripMenuItem.Name = "назадToolStripMenuItem";
            this.назадToolStripMenuItem.Size = new System.Drawing.Size(266, 30);
            this.назадToolStripMenuItem.Text = "Назад";
            this.назадToolStripMenuItem.Click += new System.EventHandler(this.назадToolStripMenuItem_Click_1);
            // 
            // фильтрыToolStripMenuItem
            // 
            this.фильтрыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.точечныеToolStripMenuItem,
            this.матричныеToolStripMenuItem,
            this.морфологияToolStripMenuItem});
            this.фильтрыToolStripMenuItem.Enabled = false;
            this.фильтрыToolStripMenuItem.Name = "фильтрыToolStripMenuItem";
            this.фильтрыToolStripMenuItem.Size = new System.Drawing.Size(88, 25);
            this.фильтрыToolStripMenuItem.Text = "Фильтры";
            // 
            // точечныеToolStripMenuItem
            // 
            this.точечныеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.инверсияToolStripMenuItem,
            this.серыеТонаToolStripMenuItem,
            this.сепияToolStripMenuItem,
            this.яркостьToolStripMenuItem,
            this.растяжениеГистограммыToolStripMenuItem,
            this.серыйМирToolStripMenuItem,
            this.идеальныйОтражательToolStripMenuItem,
            this.коррекцияСОпорнымЦветомToolStripMenuItem,
            this.перемещениеИзображенияToolStripMenuItem,
            this.поворотИзображенияToolStripMenuItem,
            this.волныToolStripMenuItem,
            this.волны2ToolStripMenuItem,
            this.стеклоToolStripMenuItem});
            this.точечныеToolStripMenuItem.Name = "точечныеToolStripMenuItem";
            this.точечныеToolStripMenuItem.Size = new System.Drawing.Size(243, 30);
            this.точечныеToolStripMenuItem.Text = "Точечные";
            // 
            // инверсияToolStripMenuItem
            // 
            this.инверсияToolStripMenuItem.Name = "инверсияToolStripMenuItem";
            this.инверсияToolStripMenuItem.Size = new System.Drawing.Size(319, 30);
            this.инверсияToolStripMenuItem.Text = "Инверсия";
            this.инверсияToolStripMenuItem.Click += new System.EventHandler(this.инверсияToolStripMenuItem_Click);
            // 
            // серыеТонаToolStripMenuItem
            // 
            this.серыеТонаToolStripMenuItem.Name = "серыеТонаToolStripMenuItem";
            this.серыеТонаToolStripMenuItem.Size = new System.Drawing.Size(319, 30);
            this.серыеТонаToolStripMenuItem.Text = "Серые тона";
            this.серыеТонаToolStripMenuItem.Click += new System.EventHandler(this.серыеТонаToolStripMenuItem_Click);
            // 
            // сепияToolStripMenuItem
            // 
            this.сепияToolStripMenuItem.Name = "сепияToolStripMenuItem";
            this.сепияToolStripMenuItem.Size = new System.Drawing.Size(319, 30);
            this.сепияToolStripMenuItem.Text = "Сепия";
            this.сепияToolStripMenuItem.Click += new System.EventHandler(this.сепияToolStripMenuItem_Click);
            // 
            // яркостьToolStripMenuItem
            // 
            this.яркостьToolStripMenuItem.Name = "яркостьToolStripMenuItem";
            this.яркостьToolStripMenuItem.Size = new System.Drawing.Size(319, 30);
            this.яркостьToolStripMenuItem.Text = "Яркость";
            this.яркостьToolStripMenuItem.Click += new System.EventHandler(this.яркостьToolStripMenuItem_Click);
            // 
            // растяжениеГистограммыToolStripMenuItem
            // 
            this.растяжениеГистограммыToolStripMenuItem.Name = "растяжениеГистограммыToolStripMenuItem";
            this.растяжениеГистограммыToolStripMenuItem.Size = new System.Drawing.Size(319, 30);
            this.растяжениеГистограммыToolStripMenuItem.Text = "Растяжение гистограммы";
            this.растяжениеГистограммыToolStripMenuItem.Click += new System.EventHandler(this.растяжениеГистограммыToolStripMenuItem_Click);
            // 
            // серыйМирToolStripMenuItem
            // 
            this.серыйМирToolStripMenuItem.Name = "серыйМирToolStripMenuItem";
            this.серыйМирToolStripMenuItem.Size = new System.Drawing.Size(319, 30);
            this.серыйМирToolStripMenuItem.Text = "Серый мир";
            this.серыйМирToolStripMenuItem.Click += new System.EventHandler(this.серыйМирToolStripMenuItem_Click);
            // 
            // идеальныйОтражательToolStripMenuItem
            // 
            this.идеальныйОтражательToolStripMenuItem.Name = "идеальныйОтражательToolStripMenuItem";
            this.идеальныйОтражательToolStripMenuItem.Size = new System.Drawing.Size(319, 30);
            this.идеальныйОтражательToolStripMenuItem.Text = "Идеальный Отражатель";
            this.идеальныйОтражательToolStripMenuItem.Click += new System.EventHandler(this.идеальныйОтражательToolStripMenuItem_Click);
            // 
            // коррекцияСОпорнымЦветомToolStripMenuItem
            // 
            this.коррекцияСОпорнымЦветомToolStripMenuItem.Name = "коррекцияСОпорнымЦветомToolStripMenuItem";
            this.коррекцияСОпорнымЦветомToolStripMenuItem.Size = new System.Drawing.Size(319, 30);
            this.коррекцияСОпорнымЦветомToolStripMenuItem.Text = "Коррекция с опорным цветом";
            this.коррекцияСОпорнымЦветомToolStripMenuItem.Click += new System.EventHandler(this.коррекцияСОпорнымЦветомToolStripMenuItem_Click);
            // 
            // перемещениеИзображенияToolStripMenuItem
            // 
            this.перемещениеИзображенияToolStripMenuItem.Name = "перемещениеИзображенияToolStripMenuItem";
            this.перемещениеИзображенияToolStripMenuItem.Size = new System.Drawing.Size(319, 30);
            this.перемещениеИзображенияToolStripMenuItem.Text = "Перемещение изображения";
            this.перемещениеИзображенияToolStripMenuItem.Click += new System.EventHandler(this.перемещениеИзображенияToolStripMenuItem_Click);
            // 
            // поворотИзображенияToolStripMenuItem
            // 
            this.поворотИзображенияToolStripMenuItem.Name = "поворотИзображенияToolStripMenuItem";
            this.поворотИзображенияToolStripMenuItem.Size = new System.Drawing.Size(319, 30);
            this.поворотИзображенияToolStripMenuItem.Text = "Поворот изображения";
            this.поворотИзображенияToolStripMenuItem.Click += new System.EventHandler(this.поворотИзображенияToolStripMenuItem_Click);
            // 
            // волныToolStripMenuItem
            // 
            this.волныToolStripMenuItem.Name = "волныToolStripMenuItem";
            this.волныToolStripMenuItem.Size = new System.Drawing.Size(319, 30);
            this.волныToolStripMenuItem.Text = "Волны1";
            this.волныToolStripMenuItem.Click += new System.EventHandler(this.волныToolStripMenuItem_Click);
            // 
            // волны2ToolStripMenuItem
            // 
            this.волны2ToolStripMenuItem.Name = "волны2ToolStripMenuItem";
            this.волны2ToolStripMenuItem.Size = new System.Drawing.Size(319, 30);
            this.волны2ToolStripMenuItem.Text = "Волны2";
            this.волны2ToolStripMenuItem.Click += new System.EventHandler(this.волны2ToolStripMenuItem_Click);
            // 
            // стеклоToolStripMenuItem
            // 
            this.стеклоToolStripMenuItem.Name = "стеклоToolStripMenuItem";
            this.стеклоToolStripMenuItem.Size = new System.Drawing.Size(319, 30);
            this.стеклоToolStripMenuItem.Text = "Стекло";
            this.стеклоToolStripMenuItem.Click += new System.EventHandler(this.стеклоToolStripMenuItem_Click);
            // 
            // матричныеToolStripMenuItem
            // 
            this.матричныеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.размытиеToolStripMenuItem,
            this.размытиеГауссToolStripMenuItem,
            this.медианныйФильтрToolStripMenuItem,
            this.фильтрСобеляToolStripMenuItem,
            this.тиснениеToolStripMenuItem,
            this.резкостьToolStripMenuItem,
            this.размытиеВДвиженииToolStripMenuItem,
            this.операторЩарраToolStripMenuItem,
            this.операторПриToolStripMenuItem,
            this.светящиесяКраяToolStripMenuItem});
            this.матричныеToolStripMenuItem.Name = "матричныеToolStripMenuItem";
            this.матричныеToolStripMenuItem.Size = new System.Drawing.Size(243, 30);
            this.матричныеToolStripMenuItem.Text = "Матричные";
            // 
            // размытиеToolStripMenuItem
            // 
            this.размытиеToolStripMenuItem.Name = "размытиеToolStripMenuItem";
            this.размытиеToolStripMenuItem.Size = new System.Drawing.Size(260, 30);
            this.размытиеToolStripMenuItem.Text = "Размытие";
            this.размытиеToolStripMenuItem.Click += new System.EventHandler(this.размытиеToolStripMenuItem_Click);
            // 
            // размытиеГауссToolStripMenuItem
            // 
            this.размытиеГауссToolStripMenuItem.Name = "размытиеГауссToolStripMenuItem";
            this.размытиеГауссToolStripMenuItem.Size = new System.Drawing.Size(260, 30);
            this.размытиеГауссToolStripMenuItem.Text = "Размытие (Гаусс)";
            this.размытиеГауссToolStripMenuItem.Click += new System.EventHandler(this.размытиеГауссToolStripMenuItem_Click);
            // 
            // медианныйФильтрToolStripMenuItem
            // 
            this.медианныйФильтрToolStripMenuItem.Name = "медианныйФильтрToolStripMenuItem";
            this.медианныйФильтрToolStripMenuItem.Size = new System.Drawing.Size(260, 30);
            this.медианныйФильтрToolStripMenuItem.Text = "Медианный фильтр";
            this.медианныйФильтрToolStripMenuItem.Click += new System.EventHandler(this.медианныйФильтрToolStripMenuItem_Click);
            // 
            // фильтрСобеляToolStripMenuItem
            // 
            this.фильтрСобеляToolStripMenuItem.Name = "фильтрСобеляToolStripMenuItem";
            this.фильтрСобеляToolStripMenuItem.Size = new System.Drawing.Size(260, 30);
            this.фильтрСобеляToolStripMenuItem.Text = "Фильтр Собеля";
            this.фильтрСобеляToolStripMenuItem.Click += new System.EventHandler(this.фильтрСобеляToolStripMenuItem_Click);
            // 
            // тиснениеToolStripMenuItem
            // 
            this.тиснениеToolStripMenuItem.Name = "тиснениеToolStripMenuItem";
            this.тиснениеToolStripMenuItem.Size = new System.Drawing.Size(260, 30);
            this.тиснениеToolStripMenuItem.Text = "Тиснение";
            this.тиснениеToolStripMenuItem.Click += new System.EventHandler(this.тиснениеToolStripMenuItem_Click);
            // 
            // резкостьToolStripMenuItem
            // 
            this.резкостьToolStripMenuItem.Name = "резкостьToolStripMenuItem";
            this.резкостьToolStripMenuItem.Size = new System.Drawing.Size(260, 30);
            this.резкостьToolStripMenuItem.Text = "Резкость";
            this.резкостьToolStripMenuItem.Click += new System.EventHandler(this.резкостьToolStripMenuItem_Click);
            // 
            // размытиеВДвиженииToolStripMenuItem
            // 
            this.размытиеВДвиженииToolStripMenuItem.Name = "размытиеВДвиженииToolStripMenuItem";
            this.размытиеВДвиженииToolStripMenuItem.Size = new System.Drawing.Size(260, 30);
            this.размытиеВДвиженииToolStripMenuItem.Text = "Размытие в движении";
            this.размытиеВДвиженииToolStripMenuItem.Click += new System.EventHandler(this.размытиеВДвиженииToolStripMenuItem_Click);
            // 
            // операторЩарраToolStripMenuItem
            // 
            this.операторЩарраToolStripMenuItem.Name = "операторЩарраToolStripMenuItem";
            this.операторЩарраToolStripMenuItem.Size = new System.Drawing.Size(260, 30);
            this.операторЩарраToolStripMenuItem.Text = "Оператор Щарра";
            this.операторЩарраToolStripMenuItem.Click += new System.EventHandler(this.операторЩарраToolStripMenuItem_Click);
            // 
            // операторПриToolStripMenuItem
            // 
            this.операторПриToolStripMenuItem.Name = "операторПриToolStripMenuItem";
            this.операторПриToolStripMenuItem.Size = new System.Drawing.Size(260, 30);
            this.операторПриToolStripMenuItem.Text = "Оператор Прюитта";
            this.операторПриToolStripMenuItem.Click += new System.EventHandler(this.операторПриToolStripMenuItem_Click);
            // 
            // светящиесяКраяToolStripMenuItem
            // 
            this.светящиесяКраяToolStripMenuItem.Name = "светящиесяКраяToolStripMenuItem";
            this.светящиесяКраяToolStripMenuItem.Size = new System.Drawing.Size(260, 30);
            this.светящиесяКраяToolStripMenuItem.Text = "Светящиеся края";
            this.светящиесяКраяToolStripMenuItem.Click += new System.EventHandler(this.светящиесяКраяToolStripMenuItem_Click);
            // 
            // морфологияToolStripMenuItem
            // 
            this.морфологияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытиеToolStripMenuItem,
            this.закрытиеToolStripMenuItem,
            this.эрозияToolStripMenuItem,
            this.расширениеToolStripMenuItem,
            this.topHatToolStripMenuItem,
            this.blackHatToolStripMenuItem,
            this.gradToolStripMenuItem});
            this.морфологияToolStripMenuItem.Name = "морфологияToolStripMenuItem";
            this.морфологияToolStripMenuItem.Size = new System.Drawing.Size(243, 30);
            this.морфологияToolStripMenuItem.Text = "Морфология";
            // 
            // открытиеToolStripMenuItem
            // 
            this.открытиеToolStripMenuItem.Name = "открытиеToolStripMenuItem";
            this.открытиеToolStripMenuItem.Size = new System.Drawing.Size(243, 30);
            this.открытиеToolStripMenuItem.Text = "Открытие";
            this.открытиеToolStripMenuItem.Click += new System.EventHandler(this.открытиеToolStripMenuItem_Click);
            // 
            // закрытиеToolStripMenuItem
            // 
            this.закрытиеToolStripMenuItem.Name = "закрытиеToolStripMenuItem";
            this.закрытиеToolStripMenuItem.Size = new System.Drawing.Size(243, 30);
            this.закрытиеToolStripMenuItem.Text = "Закрытие";
            this.закрытиеToolStripMenuItem.Click += new System.EventHandler(this.закрытиеToolStripMenuItem_Click);
            // 
            // эрозияToolStripMenuItem
            // 
            this.эрозияToolStripMenuItem.Name = "эрозияToolStripMenuItem";
            this.эрозияToolStripMenuItem.Size = new System.Drawing.Size(243, 30);
            this.эрозияToolStripMenuItem.Text = "Эрозия";
            this.эрозияToolStripMenuItem.Click += new System.EventHandler(this.эрозияToolStripMenuItem_Click_1);
            // 
            // расширениеToolStripMenuItem
            // 
            this.расширениеToolStripMenuItem.Name = "расширениеToolStripMenuItem";
            this.расширениеToolStripMenuItem.Size = new System.Drawing.Size(243, 30);
            this.расширениеToolStripMenuItem.Text = "Расширение";
            this.расширениеToolStripMenuItem.Click += new System.EventHandler(this.расширениеToolStripMenuItem_Click_1);
            // 
            // topHatToolStripMenuItem
            // 
            this.topHatToolStripMenuItem.Name = "topHatToolStripMenuItem";
            this.topHatToolStripMenuItem.Size = new System.Drawing.Size(243, 30);
            this.topHatToolStripMenuItem.Text = "Top hat";
            this.topHatToolStripMenuItem.Click += new System.EventHandler(this.topHatToolStripMenuItem_Click);
            // 
            // blackHatToolStripMenuItem
            // 
            this.blackHatToolStripMenuItem.Name = "blackHatToolStripMenuItem";
            this.blackHatToolStripMenuItem.Size = new System.Drawing.Size(243, 30);
            this.blackHatToolStripMenuItem.Text = "Black hat";
            this.blackHatToolStripMenuItem.Click += new System.EventHandler(this.blackHatToolStripMenuItem_Click);
            // 
            // gradToolStripMenuItem
            // 
            this.gradToolStripMenuItem.Name = "gradToolStripMenuItem";
            this.gradToolStripMenuItem.Size = new System.Drawing.Size(243, 30);
            this.gradToolStripMenuItem.Text = "Grad";
            this.gradToolStripMenuItem.Click += new System.EventHandler(this.gradToolStripMenuItem_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 405);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(584, 29);
            this.progressBar1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(602, 405);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 29);
            this.button1.TabIndex = 3;
            this.button1.Text = "Отмена";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 447);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem открытьToolStripMenuItem;
        private ToolStripMenuItem сохранитьToolStripMenuItem;
        private ToolStripMenuItem фильтрыToolStripMenuItem;
        private ToolStripMenuItem точечныеToolStripMenuItem;
        private ToolStripMenuItem матричныеToolStripMenuItem;
        private ToolStripMenuItem инверсияToolStripMenuItem;
        private ProgressBar progressBar1;
        private Button button1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ToolStripMenuItem размытиеToolStripMenuItem;
        private ToolStripMenuItem размытиеГауссToolStripMenuItem;
        private ToolStripMenuItem серыеТонаToolStripMenuItem;
        private ToolStripMenuItem сепияToolStripMenuItem;
        private ToolStripMenuItem яркостьToolStripMenuItem;
        private ToolStripMenuItem растяжениеГистограммыToolStripMenuItem;
        private ToolStripMenuItem медианныйФильтрToolStripMenuItem;
        private ToolStripMenuItem отменитьВсеФильтрыToolStripMenuItem;
        private ToolStripMenuItem фильтрСобеляToolStripMenuItem;
        private ToolStripMenuItem тиснениеToolStripMenuItem;
        private ToolStripMenuItem назадToolStripMenuItem;
        private ToolStripMenuItem серыйМирToolStripMenuItem;
        private ToolStripMenuItem идеальныйОтражательToolStripMenuItem;
        private ToolStripMenuItem коррекцияСОпорнымЦветомToolStripMenuItem;
        private ToolStripMenuItem перемещениеИзображенияToolStripMenuItem;
        private ToolStripMenuItem резкостьToolStripMenuItem;
        private ToolStripMenuItem размытиеВДвиженииToolStripMenuItem;
        private ToolStripMenuItem поворотИзображенияToolStripMenuItem;
        private ToolStripMenuItem волныToolStripMenuItem;
        private ToolStripMenuItem волны2ToolStripMenuItem;
        private ToolStripMenuItem стеклоToolStripMenuItem;
        private ToolStripMenuItem операторЩарраToolStripMenuItem;
        private ToolStripMenuItem операторПриToolStripMenuItem;
        private ToolStripMenuItem светящиесяКраяToolStripMenuItem;
        private ToolStripMenuItem морфологияToolStripMenuItem;
        private ToolStripMenuItem открытиеToolStripMenuItem;
        private ToolStripMenuItem закрытиеToolStripMenuItem;
        private ToolStripMenuItem эрозияToolStripMenuItem;
        private ToolStripMenuItem расширениеToolStripMenuItem;
        private ToolStripMenuItem topHatToolStripMenuItem;
        private ToolStripMenuItem blackHatToolStripMenuItem;
        private ToolStripMenuItem gradToolStripMenuItem;
    }
}