using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ETicaretDesktopAdmin.Base
{
    public partial class HomePage : Form
    {
        public delegate void MyMtsControlHandler(string name, string key);
        public MyMtsControlHandler MtsAdd;
        public MyMtsControlHandler MtsDrop;
	
	public HomePage()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            MtsAdd = new MyMtsControlHandler(this.mtsTabAdd);
            MtsDrop = new MyMtsControlHandler(this.mtsTabDrop);
        }
	
	private void mtsTabDrop(string name, string key)
        {
            int i = mtsTabs.Items.IndexOfKey(key);
            mtsTabs.Items.RemoveAt(i);
        }
	
	private void mtsTabAdd(string name, string key)
        {
            mtsTabItems.Add(
            new ToolStripMenuItem(name, null, new EventHandler(MtsTabControlOpen),key));
            foreach (ToolStripMenuItem item in mtsTabItems)
                mtsTabs.Items.Add(item);
        }
    }
}