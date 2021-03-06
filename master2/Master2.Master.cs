using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace CPHFixes.Test.master2
{
    public partial class Master2 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //output TemplateControl.AppRelativeVirtualPath
            
            //The .Parent.Parent is to account for the <div runat="server">  we are using to apply the css.
            //Without the div, it would be .Parent
            lbl1.Text = lbl1.Parent.Parent.TemplateControl.AppRelativeVirtualPath;
            if (lbl1.Text == this.AppRelativeVirtualPath) div1.Attributes.Add("class", "ok");
            else div1.Attributes.Add("class", "error");
            System.Diagnostics.Debug.Assert(lbl1.Parent.Parent is ContentPlaceHolder);

            System.Diagnostics.Debug.Assert(!(lbl2.Parent.Parent is ContentPlaceHolder));
            lbl2.Text = lbl2.Parent.Parent.TemplateControl.AppRelativeVirtualPath;
            if (lbl2.Text == this.AppRelativeVirtualPath) div2.Attributes.Add("class", "ok");
            else div2.Attributes.Add("class", "error");

            System.Diagnostics.Debug.Assert(lbl3.Parent.Parent is ContentPlaceHolder);
            lbl3.Text = NathanaelJones.WebFormsFixes.ContentPlaceHolderFixes.GetAdjustedParentTemplateControl(lbl3.Parent.Parent).AppRelativeVirtualPath;
            if (lbl3.Text == this.AppRelativeVirtualPath) div3.Attributes.Add("class", "ok");
            else div3.Attributes.Add("class", "error");
        }
  

    }
}
