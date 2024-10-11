namespace ApowerMirrorLogHandler
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AMLHandlerServiceProccessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.AMLHandlerServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // AMLHandlerServiceProccessInstaller
            // 
            this.AMLHandlerServiceProccessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.AMLHandlerServiceProccessInstaller.Password = null;
            this.AMLHandlerServiceProccessInstaller.Username = null;
            // 
            // AMLHandlerServiceInstaller
            // 
            this.AMLHandlerServiceInstaller.ServiceName = "ApowerMirrorLogHandlerService";
            this.AMLHandlerServiceInstaller.DisplayName = "AMLLogDeletor";
            this.AMLHandlerServiceInstaller.Description = "This service deletes ApowerMirror logs when its size reaches 500MB";
            this.AMLHandlerServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.AMLHandlerServiceProccessInstaller,
            this.AMLHandlerServiceInstaller});
            
        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller AMLHandlerServiceProccessInstaller;
        private System.ServiceProcess.ServiceInstaller AMLHandlerServiceInstaller;
    }
}