using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.ExceptionHandling;
using Common.Log;

namespace WebApi.Common
{
    public class CustomExceptionLogger :ExceptionLogger
    {
        public override Task LogAsync (ExceptionLoggerContext context,
            CancellationToken cancellationToken)
        {
            Logger.WriteErrorLog(context.Exception);
            return base.LogAsync(context,cancellationToken);
        }
    }
}