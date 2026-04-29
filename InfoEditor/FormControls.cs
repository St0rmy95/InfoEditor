using InfoEditor.EffectInfo;
using InfoEditor.EffectInfo.Data;
using InfoEditor.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfoEditor
{
    public class FormControls
    {
        public void SetOpacity(double opacity_choosen)
        {
            Form current_form = Application.OpenForms[0];
            current_form.Opacity = opacity_choosen;
            Properties.Settings.Default.Opacity = opacity_choosen;
            Properties.Settings.Default.Save();
        }

        public void InitializeInfoEditor(Form form, InfoEditorMain info_editor)
        {
            // Set the saved opacity
            form.Opacity = Properties.Settings.Default.Opacity;
            // Disable the image placeholders
            foreach (ToolStripDropDownButton item in info_editor.ToolMenu.Items)
            {
                var dropDownMenu = (ToolStripDropDownMenu)item.DropDown;
                dropDownMenu.ShowImageMargin = false;
            }
            // Add Custom Toolstrip Renderer
            info_editor.ToolMenu.Renderer = new ToolStripRender();           
        }
    }

    public class ToolStripRender :  ToolStripProfessionalRenderer
    {     
        public ToolStripRender() : base(new ToolStripColorTable())
        {
            RoundedEdges = false;                 
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            if (!(e.ToolStrip is ToolStrip))
                base.OnRenderToolStripBorder(e);          
        }

        protected override void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e)
        {
           // e.Graphics.Clear(Color.FromArgb(200, 200, 200));
            //e.Item.BackColor = Color.FromArgb(200, 200, 200);
            base.OnRenderDropDownButtonBackground(e);
            if (e.Item is ToolStripMenuItem)
            {
                e.Graphics.Clear(Color.Black);
                base.DrawMenuItemBackground(e);
            }
        }
        /*
        protected override void DrawMenuItemBackground(ToolStripItemRenderEventArgs e)
        {

        }
        */
        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            e.ArrowColor = Color.White;
            base.OnRenderArrow(e);
        }

    }   

    public class ToolStripColorTable : ProfessionalColorTable
    {
        Color background_highlights = Color.FromArgb(160, 25, 25);
        Color background = Color.FromArgb(30, 30, 30);
        public ToolStripColorTable()
        {
            base.UseSystemColors = false;
        }
        // Checked
        public override Color ButtonCheckedGradientBegin { get { return base.ButtonCheckedGradientBegin; } }
        public override Color ButtonCheckedGradientEnd { get { return base.ButtonCheckedGradientEnd; } }
        public override Color ButtonCheckedGradientMiddle { get { return base.ButtonCheckedGradientMiddle; } }
        public override Color ButtonCheckedHighlight { get { return base.ButtonCheckedHighlight; } }
        public override Color ButtonCheckedHighlightBorder { get { return base.ButtonCheckedHighlightBorder; } }
        // Pressed
        public override Color ButtonPressedBorder { get { return base.ButtonPressedBorder; } }
        public override Color ButtonPressedGradientBegin { get { return base.ButtonPressedGradientBegin; } }
        public override Color ButtonPressedGradientEnd { get { return base.ButtonPressedGradientEnd; } }
        public override Color ButtonPressedGradientMiddle { get { return base.ButtonPressedGradientMiddle; } }
        public override Color ButtonPressedHighlight { get { return base.ButtonPressedHighlight; } }
        public override Color ButtonPressedHighlightBorder { get { return base.ButtonPressedHighlightBorder; } }
        // Selected
        public override Color ButtonSelectedBorder { get { return background_highlights; } }
        public override Color ButtonSelectedGradientBegin { get { return background_highlights; } }
        public override Color ButtonSelectedGradientEnd { get { return background_highlights; } }
        public override Color ButtonSelectedGradientMiddle { get { return background_highlights; } }
        public override Color ButtonSelectedHighlight { get { return background_highlights; } }
        public override Color ButtonSelectedHighlightBorder { get { return background_highlights; } }
         // Check Bacground
        public override Color CheckBackground { get { return base.CheckBackground; } }
        public override Color CheckPressedBackground { get { return base.CheckPressedBackground; } }
        public override Color CheckSelectedBackground { get { return base.CheckSelectedBackground; } }
        // Grip
        public override Color GripDark { get { return base.GripDark; } }
        public override Color GripLight { get { return base.GripLight; } }
        // Image Margin
        public override Color ImageMarginGradientBegin { get { return base.ImageMarginGradientBegin; } }
        public override Color ImageMarginGradientEnd { get { return base.ImageMarginGradientEnd; } }
        public override Color ImageMarginGradientMiddle { get { return base.ImageMarginGradientMiddle; } }
        public override Color ImageMarginRevealedGradientBegin { get { return base.ImageMarginRevealedGradientBegin; } }
        public override Color ImageMarginRevealedGradientEnd { get { return base.ImageMarginRevealedGradientEnd; } }
        public override Color ImageMarginRevealedGradientMiddle { get { return base.ImageMarginRevealedGradientMiddle; } }
        // Menu Items
        public override Color MenuBorder { get { return background_highlights; } }
        public override Color MenuItemBorder { get { return background_highlights; } }
        public override Color MenuItemPressedGradientBegin { get { return background_highlights; } }
        public override Color MenuItemPressedGradientEnd { get { return background_highlights; } }
        public override Color MenuItemPressedGradientMiddle { get { return background_highlights; } }
        public override Color MenuItemSelected { get { return background_highlights; } }
        public override Color MenuItemSelectedGradientBegin { get { return background_highlights; } }
        public override Color MenuItemSelectedGradientEnd { get { return background_highlights; } }
        public override Color MenuStripGradientBegin { get { return background_highlights; } }
        public override Color MenuStripGradientEnd { get { return background_highlights; } }
        // Overflow
        public override Color OverflowButtonGradientBegin { get { return base.OverflowButtonGradientBegin; } }
        public override Color OverflowButtonGradientEnd { get { return base.OverflowButtonGradientEnd; } }
        public override Color OverflowButtonGradientMiddle { get { return base.OverflowButtonGradientMiddle; } }
        // Rafting
        public override Color RaftingContainerGradientBegin { get { return base.RaftingContainerGradientBegin; } }
        public override Color RaftingContainerGradientEnd { get { return base.RaftingContainerGradientEnd; } }
        // Separator
        public override Color SeparatorDark { get { return base.SeparatorDark; } }
        public override Color SeparatorLight { get { return base.SeparatorLight; } }
        // Status Strip
        public override Color StatusStripGradientBegin { get { return base.StatusStripGradientBegin; } }
        public override Color StatusStripGradientEnd { get { return base.StatusStripGradientEnd; } }
        // Tool Strip
        public override Color ToolStripBorder { get { return Color.Transparent; } }
        public override Color ToolStripContentPanelGradientBegin { get { return base.ToolStripContentPanelGradientBegin; } }
        public override Color ToolStripContentPanelGradientEnd { get { return base.ToolStripContentPanelGradientEnd; } }
        public override Color ToolStripDropDownBackground { get { return base.ToolStripDropDownBackground; } }
        public override Color ToolStripGradientBegin { get { return base.ToolStripGradientBegin; } }
        public override Color ToolStripGradientEnd { get { return base.ToolStripGradientEnd; } }
        public override Color ToolStripGradientMiddle { get { return base.ToolStripGradientMiddle; } }
        public override Color ToolStripPanelGradientBegin { get { return base.ToolStripPanelGradientBegin; } }
        public override Color ToolStripPanelGradientEnd { get { return base.ToolStripPanelGradientEnd; } }
    }
}
