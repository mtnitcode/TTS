using Sbn.Products.TTS.Present;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GovTTSPresent
{
    public class Services : CommonInterface.UIInitiator
    {
        public override object GetCorrelateControl(Sbn.Systems.WMC.WMCObject.UserInterface userInterface)
        {
            throw new NotImplementedException();
        }

        public override CommonInterface.UIInitiator GetInstance()
        {
            return new Services();
        }

        public override CommonInterface.IObjectSelector GetObjectSelector(object maibObj, Type objT)
        {
            throw new NotImplementedException();
        }

        public override CommonInterface.ISbnObjectViewer GetObjectViewer(object maibObj, Type objT)
        {
            throw new NotImplementedException();
        }

        Sbn.Products.TTS.Present.Main frm = null;

        public override System.Windows.Forms.Form InitialUI(Sbn.Systems.WMC.WMCObject.UserInterface userInterface, Sbn.Systems.WMC.WMCObject.Activity activity, System.Windows.Forms.Form MDIForm, Sbn.Systems.WMC.WMCObject.Worker worker)
        {

            return InitialUI(userInterface, MDIForm, worker);
        }

        public override System.Windows.Forms.Form InitialUI(Sbn.Systems.WMC.WMCObject.WorkContext workContext, System.Windows.Forms.Form MDIForm, Sbn.Systems.WMC.WMCObject.Worker worker)
        {
            
            return null;
        }

        public override System.Windows.Forms.Form InitialUI(Sbn.Systems.WMC.WMCObject.UserInterface userInterface, System.Windows.Forms.Form MDIForm, Sbn.Systems.WMC.WMCObject.Worker worker)
        {

            Main._callFromExtApp = true;
            if(worker != null)
                Main._Name = worker.Title;

            if (frm == null)
                frm = new Sbn.Products.TTS.Present.Main();

            frm.خروجToolStripMenuItem.Visible = false;
            return null;
        }

        public override Sbn.Libs.ClientTools.IServiceClient Service
        {
            get { return null; }
        }

        public override void StopService()
        {

            if (frm != null)
            {
                frm.StopThreads();
                frm.Dispose();
            }
        }

        public override long SubSystemCode
        {
            get { return 13; }
        }
    }
}
