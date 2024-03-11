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
            pictureBox1 = new PictureBox();
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            открытьToolStripMenuItem = new ToolStripMenuItem();
            сохранитьToolStripMenuItem = new ToolStripMenuItem();
            отменитьВсеФильтрыToolStripMenuItem = new ToolStripMenuItem();
            назадToolStripMenuItem = new ToolStripMenuItem();
            фильтрыToolStripMenuItem = new ToolStripMenuItem();
            точечныеToolStripMenuItem = new ToolStripMenuItem();
            инверсияToolStripMenuItem = new ToolStripMenuItem();
            серыеТонаToolStripMenuItem = new ToolStripMenuItem();
            сепияToolStripMenuItem = new ToolStripMenuItem();
            яркостьToolStripMenuItem = new ToolStripMenuItem();
            растяжениеГистограммыToolStripMenuItem = new ToolStripMenuItem();
            серыйМирToolStripMenuItem = new ToolStripMenuItem();
            идеальныйОтражательToolStripMenuItem = new ToolStripMenuItem();
            коррекцияСОпорнымЦветомToolStripMenuItem = new ToolStripMenuItem();
            расширениеToolStripMenuItem = new ToolStripMenuItem();
            перемещениеИзображенияToolStripMenuItem = new ToolStripMenuItem();
            поворотИзображенияToolStripMenuItem = new ToolStripMenuItem();
            волныToolStripMenuItem = new ToolStripMenuItem();
            волны2ToolStripMenuItem = new ToolStripMenuItem();
            стеклоToolStripMenuItem = new ToolStripMenuItem();
            матричныеToolStripMenuItem = new ToolStripMenuItem();
            размытиеToolStripMenuItem = new ToolStripMenuItem();
            размытиеГауссToolStripMenuItem = new ToolStripMenuItem();
            медианныйФильтрToolStripMenuItem = new ToolStripMenuItem();
            фильтрСобеляToolStripMenuItem = new ToolStripMenuItem();
            тиснениеToolStripMenuItem = new ToolStripMenuItem();
            резкостьToolStripMenuItem = new ToolStripMenuItem();
            размытиеВДвиженииToolStripMenuItem = new ToolStripMenuItem();
            операторЩарраToolStripMenuItem = new ToolStripMenuItem();
            операторПриToolStripMenuItem = new ToolStripMenuItem();
            светящиесяКраяToolStripMenuItem = new ToolStripMenuItem();
            progressBar1 = new ProgressBar();
            button1 = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            эрозияToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Location = new Point(0, 19);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(562, 265);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(22, 22);
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, фильтрыToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 1, 0, 1);
            menuStrip1.Size = new Size(562, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { открытьToolStripMenuItem, сохранитьToolStripMenuItem, отменитьВсеФильтрыToolStripMenuItem, назадToolStripMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(48, 22);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            открытьToolStripMenuItem.Size = new Size(202, 22);
            открытьToolStripMenuItem.Text = "Открыть";
            открытьToolStripMenuItem.Click += открытьToolStripMenuItem_Click;
            // 
            // сохранитьToolStripMenuItem
            // 
            сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            сохранитьToolStripMenuItem.Size = new Size(202, 22);
            сохранитьToolStripMenuItem.Text = "Сохранить";
            сохранитьToolStripMenuItem.Click += сохранитьToolStripMenuItem_Click;
            // 
            // отменитьВсеФильтрыToolStripMenuItem
            // 
            отменитьВсеФильтрыToolStripMenuItem.Name = "отменитьВсеФильтрыToolStripMenuItem";
            отменитьВсеФильтрыToolStripMenuItem.Size = new Size(202, 22);
            отменитьВсеФильтрыToolStripMenuItem.Text = "Отменить все фильтры";
            отменитьВсеФильтрыToolStripMenuItem.Click += отменитьВсеФильтрыToolStripMenuItem_Click;
            // 
            // назадToolStripMenuItem
            // 
            назадToolStripMenuItem.Name = "назадToolStripMenuItem";
            назадToolStripMenuItem.Size = new Size(202, 22);
            назадToolStripMenuItem.Text = "Назад";
            назадToolStripMenuItem.Click += назадToolStripMenuItem_Click_1;
            // 
            // фильтрыToolStripMenuItem
            // 
            фильтрыToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { точечныеToolStripMenuItem, матричныеToolStripMenuItem });
            фильтрыToolStripMenuItem.Enabled = false;
            фильтрыToolStripMenuItem.Name = "фильтрыToolStripMenuItem";
            фильтрыToolStripMenuItem.Size = new Size(69, 22);
            фильтрыToolStripMenuItem.Text = "Фильтры";
            // 
            // точечныеToolStripMenuItem
            // 
            точечныеToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { инверсияToolStripMenuItem, серыеТонаToolStripMenuItem, сепияToolStripMenuItem, яркостьToolStripMenuItem, растяжениеГистограммыToolStripMenuItem, серыйМирToolStripMenuItem, идеальныйОтражательToolStripMenuItem, коррекцияСОпорнымЦветомToolStripMenuItem, расширениеToolStripMenuItem, эрозияToolStripMenuItem, перемещениеИзображенияToolStripMenuItem, поворотИзображенияToolStripMenuItem, волныToolStripMenuItem, волны2ToolStripMenuItem, стеклоToolStripMenuItem });
            точечныеToolStripMenuItem.Name = "точечныеToolStripMenuItem";
            точечныеToolStripMenuItem.Size = new Size(180, 22);
            точечныеToolStripMenuItem.Text = "Точечные";
            // 
            // инверсияToolStripMenuItem
            // 
            инверсияToolStripMenuItem.Name = "инверсияToolStripMenuItem";
            инверсияToolStripMenuItem.Size = new Size(242, 22);
            инверсияToolStripMenuItem.Text = "Инверсия";
            инверсияToolStripMenuItem.Click += инверсияToolStripMenuItem_Click;
            // 
            // серыеТонаToolStripMenuItem
            // 
            серыеТонаToolStripMenuItem.Name = "серыеТонаToolStripMenuItem";
            серыеТонаToolStripMenuItem.Size = new Size(242, 22);
            серыеТонаToolStripMenuItem.Text = "Серые тона";
            серыеТонаToolStripMenuItem.Click += серыеТонаToolStripMenuItem_Click;
            // 
            // сепияToolStripMenuItem
            // 
            сепияToolStripMenuItem.Name = "сепияToolStripMenuItem";
            сепияToolStripMenuItem.Size = new Size(242, 22);
            сепияToolStripMenuItem.Text = "Сепия";
            сепияToolStripMenuItem.Click += сепияToolStripMenuItem_Click;
            // 
            // яркостьToolStripMenuItem
            // 
            яркостьToolStripMenuItem.Name = "яркостьToolStripMenuItem";
            яркостьToolStripMenuItem.Size = new Size(242, 22);
            яркостьToolStripMenuItem.Text = "Яркость";
            яркостьToolStripMenuItem.Click += яркостьToolStripMenuItem_Click;
            // 
            // растяжениеГистограммыToolStripMenuItem
            // 
            растяжениеГистограммыToolStripMenuItem.Name = "растяжениеГистограммыToolStripMenuItem";
            растяжениеГистограммыToolStripMenuItem.Size = new Size(242, 22);
            растяжениеГистограммыToolStripMenuItem.Text = "Растяжение гистограммы";
            растяжениеГистограммыToolStripMenuItem.Click += растяжениеГистограммыToolStripMenuItem_Click;
            // 
            // серыйМирToolStripMenuItem
            // 
            серыйМирToolStripMenuItem.Name = "серыйМирToolStripMenuItem";
            серыйМирToolStripMenuItem.Size = new Size(242, 22);
            серыйМирToolStripMenuItem.Text = "Серый мир";
            серыйМирToolStripMenuItem.Click += серыйМирToolStripMenuItem_Click;
            // 
            // идеальныйОтражательToolStripMenuItem
            // 
            идеальныйОтражательToolStripMenuItem.Name = "идеальныйОтражательToolStripMenuItem";
            идеальныйОтражательToolStripMenuItem.Size = new Size(242, 22);
            идеальныйОтражательToolStripMenuItem.Text = "Идеальный Отражатель";
            идеальныйОтражательToolStripMenuItem.Click += идеальныйОтражательToolStripMenuItem_Click;
            // 
            // коррекцияСОпорнымЦветомToolStripMenuItem
            // 
            коррекцияСОпорнымЦветомToolStripMenuItem.Name = "коррекцияСОпорнымЦветомToolStripMenuItem";
            коррекцияСОпорнымЦветомToolStripMenuItem.Size = new Size(242, 22);
            коррекцияСОпорнымЦветомToolStripMenuItem.Text = "Коррекция с опорным цветом";
            коррекцияСОпорнымЦветомToolStripMenuItem.Click += коррекцияСОпорнымЦветомToolStripMenuItem_Click;
            // 
            // расширениеToolStripMenuItem
            // 
            расширениеToolStripMenuItem.Name = "расширениеToolStripMenuItem";
            расширениеToolStripMenuItem.Size = new Size(242, 22);
            расширениеToolStripMenuItem.Text = "Расширение";
            расширениеToolStripMenuItem.Click += расширениеToolStripMenuItem_Click;
            // 
            // перемещениеИзображенияToolStripMenuItem
            // 
            перемещениеИзображенияToolStripMenuItem.Name = "перемещениеИзображенияToolStripMenuItem";
            перемещениеИзображенияToolStripMenuItem.Size = new Size(242, 22);
            перемещениеИзображенияToolStripMenuItem.Text = "Перемещение изображения";
            перемещениеИзображенияToolStripMenuItem.Click += перемещениеИзображенияToolStripMenuItem_Click;
            // 
            // поворотИзображенияToolStripMenuItem
            // 
            поворотИзображенияToolStripMenuItem.Name = "поворотИзображенияToolStripMenuItem";
            поворотИзображенияToolStripMenuItem.Size = new Size(242, 22);
            поворотИзображенияToolStripMenuItem.Text = "Поворот изображения";
            поворотИзображенияToolStripMenuItem.Click += поворотИзображенияToolStripMenuItem_Click;
            // 
            // волныToolStripMenuItem
            // 
            волныToolStripMenuItem.Name = "волныToolStripMenuItem";
            волныToolStripMenuItem.Size = new Size(242, 22);
            волныToolStripMenuItem.Text = "Волны1";
            волныToolStripMenuItem.Click += волныToolStripMenuItem_Click;
            // 
            // волны2ToolStripMenuItem
            // 
            волны2ToolStripMenuItem.Name = "волны2ToolStripMenuItem";
            волны2ToolStripMenuItem.Size = new Size(242, 22);
            волны2ToolStripMenuItem.Text = "Волны2";
            волны2ToolStripMenuItem.Click += волны2ToolStripMenuItem_Click;
            // 
            // стеклоToolStripMenuItem
            // 
            стеклоToolStripMenuItem.Name = "стеклоToolStripMenuItem";
            стеклоToolStripMenuItem.Size = new Size(242, 22);
            стеклоToolStripMenuItem.Text = "Стекло";
            стеклоToolStripMenuItem.Click += стеклоToolStripMenuItem_Click;
            // 
            // матричныеToolStripMenuItem
            // 
            матричныеToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { размытиеToolStripMenuItem, размытиеГауссToolStripMenuItem, медианныйФильтрToolStripMenuItem, фильтрСобеляToolStripMenuItem, тиснениеToolStripMenuItem, резкостьToolStripMenuItem, размытиеВДвиженииToolStripMenuItem, операторЩарраToolStripMenuItem, операторПриToolStripMenuItem, светящиесяКраяToolStripMenuItem });
            матричныеToolStripMenuItem.Name = "матричныеToolStripMenuItem";
            матричныеToolStripMenuItem.Size = new Size(180, 22);
            матричныеToolStripMenuItem.Text = "Матричные";
            // 
            // размытиеToolStripMenuItem
            // 
            размытиеToolStripMenuItem.Name = "размытиеToolStripMenuItem";
            размытиеToolStripMenuItem.Size = new Size(195, 22);
            размытиеToolStripMenuItem.Text = "Размытие";
            размытиеToolStripMenuItem.Click += размытиеToolStripMenuItem_Click;
            // 
            // размытиеГауссToolStripMenuItem
            // 
            размытиеГауссToolStripMenuItem.Name = "размытиеГауссToolStripMenuItem";
            размытиеГауссToolStripMenuItem.Size = new Size(195, 22);
            размытиеГауссToolStripMenuItem.Text = "Размытие (Гаусс)";
            размытиеГауссToolStripMenuItem.Click += размытиеГауссToolStripMenuItem_Click;
            // 
            // медианныйФильтрToolStripMenuItem
            // 
            медианныйФильтрToolStripMenuItem.Name = "медианныйФильтрToolStripMenuItem";
            медианныйФильтрToolStripMenuItem.Size = new Size(195, 22);
            медианныйФильтрToolStripMenuItem.Text = "Медианный фильтр";
            медианныйФильтрToolStripMenuItem.Click += медианныйФильтрToolStripMenuItem_Click;
            // 
            // фильтрСобеляToolStripMenuItem
            // 
            фильтрСобеляToolStripMenuItem.Name = "фильтрСобеляToolStripMenuItem";
            фильтрСобеляToolStripMenuItem.Size = new Size(195, 22);
            фильтрСобеляToolStripMenuItem.Text = "Фильтр Собеля";
            фильтрСобеляToolStripMenuItem.Click += фильтрСобеляToolStripMenuItem_Click;
            // 
            // тиснениеToolStripMenuItem
            // 
            тиснениеToolStripMenuItem.Name = "тиснениеToolStripMenuItem";
            тиснениеToolStripMenuItem.Size = new Size(195, 22);
            тиснениеToolStripMenuItem.Text = "Тиснение";
            тиснениеToolStripMenuItem.Click += тиснениеToolStripMenuItem_Click;
            // 
            // резкостьToolStripMenuItem
            // 
            резкостьToolStripMenuItem.Name = "резкостьToolStripMenuItem";
            резкостьToolStripMenuItem.Size = new Size(195, 22);
            резкостьToolStripMenuItem.Text = "Резкость";
            резкостьToolStripMenuItem.Click += резкостьToolStripMenuItem_Click;
            // 
            // размытиеВДвиженииToolStripMenuItem
            // 
            размытиеВДвиженииToolStripMenuItem.Name = "размытиеВДвиженииToolStripMenuItem";
            размытиеВДвиженииToolStripMenuItem.Size = new Size(195, 22);
            размытиеВДвиженииToolStripMenuItem.Text = "Размытие в движении";
            размытиеВДвиженииToolStripMenuItem.Click += размытиеВДвиженииToolStripMenuItem_Click;
            // 
            // операторЩарраToolStripMenuItem
            // 
            операторЩарраToolStripMenuItem.Name = "операторЩарраToolStripMenuItem";
            операторЩарраToolStripMenuItem.Size = new Size(195, 22);
            операторЩарраToolStripMenuItem.Text = "Оператор Щарра";
            операторЩарраToolStripMenuItem.Click += операторЩарраToolStripMenuItem_Click;
            // 
            // операторПриToolStripMenuItem
            // 
            операторПриToolStripMenuItem.Name = "операторПриToolStripMenuItem";
            операторПриToolStripMenuItem.Size = new Size(195, 22);
            операторПриToolStripMenuItem.Text = "Оператор Прюитта";
            операторПриToolStripMenuItem.Click += операторПриToolStripMenuItem_Click;
            // 
            // светящиесяКраяToolStripMenuItem
            // 
            светящиесяКраяToolStripMenuItem.Name = "светящиесяКраяToolStripMenuItem";
            светящиесяКраяToolStripMenuItem.Size = new Size(195, 22);
            светящиесяКраяToolStripMenuItem.Text = "Светящиеся края";
            светящиесяКраяToolStripMenuItem.Click += светящиесяКраяToolStripMenuItem_Click;
            // 
            // progressBar1
            // 
            progressBar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            progressBar1.Location = new Point(9, 289);
            progressBar1.Margin = new Padding(2);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(454, 21);
            progressBar1.TabIndex = 2;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(468, 289);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(84, 21);
            button1.TabIndex = 3;
            button1.Text = "Отмена";
            button1.UseVisualStyleBackColor = true;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // эрозияToolStripMenuItem
            // 
            эрозияToolStripMenuItem.Name = "эрозияToolStripMenuItem";
            эрозияToolStripMenuItem.Size = new Size(242, 22);
            эрозияToolStripMenuItem.Text = "Эрозия";
            эрозияToolStripMenuItem.Click += эрозияToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(562, 319);
            Controls.Add(button1);
            Controls.Add(progressBar1);
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(2);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private ToolStripMenuItem расширениеToolStripMenuItem;
        private ToolStripMenuItem эрозияToolStripMenuItem;
    }
}