using FluentScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExcelExport.Services
{
    public class JobRegistry : Registry
    {
        public JobRegistry()
        {

           
           // DivSch().ToRunOnceIn(30).Seconds();
           

        }

        //div service - 
        //private Schedule DivSch()
        //{
        //    return Schedule(() => { (new service()).Execute(); });
        //}

    }
    //public class Divident : IJob, IRegisteredObject
    //{
    //    private readonly object _lock = new object();

    //    private bool _shuttingDown;

    //    public Divident()
    //    {
    //        // Register this job with the hosting environment.
    //        // Allows for a more graceful stop of the job, in the case of IIS shutting down.
    //        HostingEnvironment.RegisterObject(this);
    //    }

    //    public void Execute()
    //    {
    //        lock (_lock)
    //        {
    //            if (_shuttingDown)
    //                return;

    //            try
    //            {
    //                // Do work, son!
                    

                    
    //                //var mail = new System.Net.Mail.MailMessage("system@indianportfoliotracker.azurewebsites.net", "karan.b2001@gmail.com", "Divident Refresh Successful", $"Numerous entries added to Dividents");
    //                //new SmtpClient().Send(mail);
    //            }
    //            catch (Exception e)
    //            {
    //                Trace.TraceError($"Job:Divident:Outer:{e.Message}", e);
    //            }


    //        }
    //    }



    //    public void Stop(bool immediate)
    //    {
    //        // Locking here will wait for the lock in Execute to be released until this code can continue.
    //        lock (_lock)
    //        {
    //            _shuttingDown = true;
    //        }

    //        HostingEnvironment.UnregisterObject(this);
    //    }

    //}
}