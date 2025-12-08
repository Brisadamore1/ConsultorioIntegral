using System.Drawing;
using System.Windows.Forms;

namespace Desktop.Helpers
{
    public class CustomMenuColorTable : ProfessionalColorTable
    {
        // Fondo del dropdown / menú
        public override Color ToolStripDropDownBackground => Color.FromArgb(15, 22, 41);

        // Fondo del menu principal (gradiente)
        public override Color ToolStripGradientBegin => Color.FromArgb(15, 22, 41);
        public override Color ToolStripGradientEnd => Color.FromArgb(15, 22, 41);

        // Color cuando el item está seleccionado (hover) -> Gris oscuro
        public override Color MenuItemSelected => Color.FromArgb(54, 57, 63);
        public override Color MenuItemSelectedGradientBegin => Color.FromArgb(54, 57, 63);
        public override Color MenuItemSelectedGradientEnd => Color.FromArgb(48, 50, 56);

        // Color cuando el item está presionado -> Gris aún más oscuro
        public override Color MenuItemPressedGradientBegin => Color.FromArgb(40, 42, 46);
        public override Color MenuItemPressedGradientEnd => Color.FromArgb(34, 36, 40);

        // Mantener margen de imagen consistente con el tema oscuro
        public override Color ImageMarginGradientBegin => Color.FromArgb(15, 22, 41);
        public override Color ImageMarginGradientMiddle => Color.FromArgb(15, 22, 41);
        public override Color ImageMarginGradientEnd => Color.FromArgb(15, 22, 41);

        // Borde del item seleccionado (sutil)
        public override Color MenuItemBorder => Color.FromArgb(70, 74, 80);
    }
}