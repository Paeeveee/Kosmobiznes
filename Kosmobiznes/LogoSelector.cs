using System.Drawing;
using System.Windows.Forms;

namespace Kosmobiznes
{
    /// <summary>
    /// Creates a ComboBox capable of displaying images as list elements
    /// </summary>
    public class LogoSelector : ComboBox
    {
        /// <summary>
        /// Constructor method fo LogoSelector class
        /// </summary>
        public LogoSelector()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// Overridden method OnDrawItem()
        /// </summary>
        /// <param name="e">DrawItemEventArgs object</param>
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            if (e.Index >= 0 && e.Index < Items.Count)
            {
                DropDownItem item = (DropDownItem)Items[e.Index];

                e.Graphics.DrawImage(item.Image, e.Bounds.Left, e.Bounds.Top);
            }
            base.OnDrawItem(e);
        }
    }

    /// <summary>
    /// Stores an Image for drop down list element.
    /// </summary>
    public sealed class DropDownItem
    {
        public Image Image { get; set; }
    }
}
