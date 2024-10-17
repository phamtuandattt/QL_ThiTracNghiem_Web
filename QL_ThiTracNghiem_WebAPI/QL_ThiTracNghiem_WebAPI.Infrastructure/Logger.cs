using log4net;
using System.Reflection;
using System.Web;

namespace QL_ThiTracNghiem_WebAPI.Infrastructure
{
    public static class Logger
    {
        private readonly static ILog Log;

        static Logger()
        {
            var loggerName = string.Empty;
            var declaringType = MethodBase.GetCurrentMethod()?.DeclaringType;
            if (declaringType is not null)
            {
                loggerName = declaringType.Name;
            }
            Log = LogManager.GetLogger(loggerName);

            log4net.Config.XmlConfigurator.Configure();
        }
        public static void Warn(object msg)
        {
            var encodeMsg = EndcodeMessage(msg);
            Log.Error(encodeMsg);
        }
        public static void Error(object msg)
        {
            var encodeMsg = EndcodeMessage(msg);
            Log.Error(encodeMsg);
        }

        public static void Error(object msg, Exception ex)
        {
            var encodeMsg = EndcodeMessage(msg);
            Log.Error(encodeMsg, ex);
        }

        public static void Error(Exception ex)
        {
            var encodeEx = EndcodeMessage(ex.Message);
            Log.Error(encodeEx, ex);
        }

        public static void Info(object msg)
        {
            var encodeMsg = EndcodeMessage(msg);
            Log.Info(encodeMsg);
        }

        public static void Debug(object msg)
        {
            var encodeMsg = EndcodeMessage(msg);
            Log.Debug(encodeMsg);
        }

        private static string EndcodeMessage(object msg)
        {
            if (msg != null && msg.ToString() != string.Empty)
            {
                var encodeMsg = HttpUtility.HtmlEncode(msg?.ToString()?.Replace('\n', '_').Replace('\r', '_'));

                return encodeMsg ?? string.Empty;
            }
            return string.Empty;
        }
    }
}
