using System;
using System.Drawing;
using System.Windows.Forms;

namespace WDBXEditor.Common
{
    public static class ThemeManager
    {
        // --- COLORES MODO OSCURO ---
        private static readonly Color DarkBackground = Color.FromArgb(37, 37, 38);   // Fondo del formulario
        private static readonly Color DarkControlBg = Color.FromArgb(30, 30, 30);    // Fondo de tablas y cajas de texto
        private static readonly Color DarkText = Color.White;                        // Texto principal
        private static readonly Color DarkGridLine = Color.FromArgb(63, 63, 70);     // Líneas separadoras de la tabla
        private static readonly Color DarkButton = Color.FromArgb(62, 62, 66);       // Botones y cabeceras

        // --- COLORES MODO CLARO (Predeterminados de Windows) ---
        private static readonly Color LightBackground = SystemColors.Control;
        private static readonly Color LightControlBg = SystemColors.Window;
        private static readonly Color LightText = SystemColors.ControlText;
        private static readonly Color LightGridLine = SystemColors.ControlDark;
        private static readonly Color LightButton = SystemColors.Control;

        public static void ApplyTheme(Form form, bool isDarkMode)
        {
            // Fondo general de la ventana principal
            form.BackColor = isDarkMode ? DarkBackground : LightBackground;
            form.ForeColor = isDarkMode ? DarkText : LightText;

            ApplyThemeRecursively(form, isDarkMode);
        }

        private static void ApplyThemeRecursively(Control parent, bool isDarkMode)
        {
            foreach (Control control in parent.Controls)
            {
                // 1. Recorremos los controles hijos primero (si es un Panel o GroupBox con cosas adentro)
                if (control.HasChildren)
                {
                    ApplyThemeRecursively(control, isDarkMode);
                }

                // 2. Barra de Menú superior (File, Edit, Export...)
                if (control is MenuStrip menu)
                {
                    menu.BackColor = isDarkMode ? DarkBackground : LightBackground;
                    menu.ForeColor = isDarkMode ? DarkText : LightText;

                    // Aplicamos nuestro pincel especial si es modo oscuro
                    if (isDarkMode)
                    {
                        menu.Renderer = new DarkMenuRenderer();
                    }
                    else
                    {
                        // Si vuelve al modo claro, restauramos el pincel original de Windows
                        menu.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                    }
                }

                // 3. La tabla principal de datos (AdvancedDataGridView)
                else if (control is DataGridView grid)
                {
                    grid.BackgroundColor = isDarkMode ? DarkBackground : SystemColors.AppWorkspace;
                    grid.GridColor = isDarkMode ? DarkGridLine : LightGridLine;

                    // Celdas normales
                    grid.DefaultCellStyle.BackColor = isDarkMode ? DarkControlBg : LightControlBg;
                    grid.DefaultCellStyle.ForeColor = isDarkMode ? DarkText : LightText;
                    grid.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
                    grid.DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;

                    // Cabeceras superiores (ID, Category, DispelType...)
                    grid.ColumnHeadersDefaultCellStyle.BackColor = isDarkMode ? DarkButton : SystemColors.Control;
                    grid.ColumnHeadersDefaultCellStyle.ForeColor = isDarkMode ? DarkText : LightText;

                    // Cabecera lateral (La columna de la izquierda con la flecha)
                    grid.RowHeadersDefaultCellStyle.BackColor = isDarkMode ? DarkButton : SystemColors.Control;
                    grid.RowHeadersDefaultCellStyle.ForeColor = isDarkMode ? DarkText : LightText;

                    // ¡CRÍTICO! Apaga los estilos de Windows para que la cabecera acepte el color oscuro
                    grid.EnableHeadersVisualStyles = !isDarkMode;
                }

                // 4. Cajas de texto y Listas (Paneles inferiores de Files, Filter y Statistics)
                else if (control is TextBox || control is ListBox)
                {
                    control.BackColor = isDarkMode ? DarkControlBg : LightControlBg;
                    control.ForeColor = isDarkMode ? DarkText : LightText;

                    // Aplanamos el borde para que no se vea en 3D blanco
                    if (control is TextBox txt)
                    {
                        txt.BorderStyle = isDarkMode ? BorderStyle.FixedSingle : BorderStyle.Fixed3D;
                    }
                }

                // 5. Desplegables (Columns mode: None, [All])
                else if (control is ComboBox combo)
                {
                    combo.BackColor = isDarkMode ? DarkControlBg : LightControlBg;
                    combo.ForeColor = isDarkMode ? DarkText : LightText;
                    combo.FlatStyle = isDarkMode ? FlatStyle.Flat : FlatStyle.Standard;
                }

                // 6. Botones (Botón "Reset")
                else if (control is Button btn)
                {
                    btn.BackColor = isDarkMode ? DarkButton : LightButton;
                    btn.ForeColor = isDarkMode ? DarkText : LightText;
                    btn.FlatStyle = isDarkMode ? FlatStyle.Flat : FlatStyle.Standard;
                    if (isDarkMode)
                    {
                        btn.FlatAppearance.BorderColor = DarkGridLine;
                    }
                }

                // 7. Agrupadores y Paneles
                else if (control is GroupBox || control is Panel)
                {
                    control.BackColor = isDarkMode ? DarkBackground : LightBackground;
                    control.ForeColor = isDarkMode ? DarkText : LightText;
                }

                // 8. Etiquetas (Labels como "Filter:", "Build:")
                else if (control is Label lbl)
                {
                    lbl.ForeColor = isDarkMode ? DarkText : LightText;
                    lbl.BackColor = Color.Transparent; // Hereda el color oscuro de fondo limpiamente
                }
            }
        }
    }
    // --- CLASES ESPECIALES PARA RENDERIZAR EL MENÚ EN OSCURO ---
    internal class DarkMenuRenderer : ToolStripProfessionalRenderer
    {
        public DarkMenuRenderer() : base(new DarkMenuColorTable()) { }

        // Fuerza a que todo el texto dentro de los menús desplegables sea blanco
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.TextColor = Color.White;
            base.OnRenderItemText(e);
        }
    }

    internal class DarkMenuColorTable : ProfessionalColorTable
    {
        // Agregamos 'readonly' para resolver la sugerencia IDE0044
        private readonly Color DarkBg = Color.FromArgb(37, 37, 38);
        private readonly Color DarkSelected = Color.FromArgb(62, 62, 66);
        private readonly Color DarkBorder = Color.FromArgb(63, 63, 70);

        // Sobrescribimos los colores brillantes de Windows
        public override Color ToolStripDropDownBackground => DarkBg;
        public override Color ImageMarginGradientBegin => DarkBg; // Fondo donde van los íconos
        public override Color ImageMarginGradientMiddle => DarkBg;
        public override Color ImageMarginGradientEnd => DarkBg;
        public override Color MenuBorder => DarkBorder;
        public override Color MenuItemBorder => DarkBorder;
        public override Color MenuItemSelected => DarkSelected; // Color al pasar el mouse
        public override Color MenuStripGradientBegin => DarkBg;
        public override Color MenuStripGradientEnd => DarkBg;
        public override Color MenuItemSelectedGradientBegin => DarkSelected;
        public override Color MenuItemSelectedGradientEnd => DarkSelected;
        public override Color MenuItemPressedGradientBegin => DarkBg; // Color al dar clic (El que causaba tu error)
        public override Color MenuItemPressedGradientEnd => DarkBg;
    }
}

internal class DarkMenuColorTable : ProfessionalColorTable
{
        // Usamos los mismos colores de la paleta principal
        private readonly Color DarkBg = Color.FromArgb(37, 37, 38);
        private readonly Color DarkSelected = Color.FromArgb(62, 62, 66);
        private readonly Color DarkBorder = Color.FromArgb(63, 63, 70);

        // Sobrescribimos los colores brillantes de Windows
        public override Color ToolStripDropDownBackground => DarkBg;
        public override Color ImageMarginGradientBegin => DarkBg; // Fondo donde van los íconos
        public override Color ImageMarginGradientMiddle => DarkBg;
        public override Color ImageMarginGradientEnd => DarkBg;
        public override Color MenuBorder => DarkBorder;
        public override Color MenuItemBorder => DarkBorder;
        public override Color MenuItemSelected => DarkSelected; // Color al pasar el mouse
        public override Color MenuStripGradientBegin => DarkBg;
        public override Color MenuStripGradientEnd => DarkBg;
        public override Color MenuItemSelectedGradientBegin => DarkSelected;
        public override Color MenuItemSelectedGradientEnd => DarkSelected;
        public override Color MenuItemPressedGradientBegin => DarkBg; // Color al dar clic (El que causaba tu error)
        public override Color MenuItemPressedGradientEnd => DarkBg;
}