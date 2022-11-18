using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
namespace ETicaretDesktopAdmin.Control
{
    public static class PageControl
    {
        private static List<Form> activeForm = new List<Form>();
        private static bool activeFormStatu = true;
        public static void OpenPage(Form childForm)
        {
            foreach (Form form in activeForm)
            {
                if (form.Name == childForm.Name)
                {
                    activeFormStatu = false;
                    break;
                }
                else
                {
                    activeFormStatu = true;
                }
            }
            if (activeFormStatu)
            {
                activeForm.Add(childForm);
                childForm.MdiParent = HomePage.ActiveForm;
                childForm.Show();
                HomePage frm = (HomePage)Application.OpenForms["HomePage"];
                frm.MtsAdd.Invoke(childForm.Text, childForm.Name);
                frm.LeftPanelAdd.Invoke(1);
            }
            else { mtsTabControlOpen(childForm.Text); }
        }
        public static void ClosePage(Form childForm)
        {
            if (activeForm.Count == 0)
            {
                activeForm.Remove(childForm);
                HomePage frm = (HomePage)Application.OpenForms["HomePage"];
                frm.MtsDrop.Invoke(childForm.Text, childForm.Name);
            }

        }
        public static void mtsTabControlOpen(string name)
        {
            foreach (var form in activeForm)
            {
                if (form.Text == name)
                {
                    form.BringToFront();
                }
            }
        }
    }

}
