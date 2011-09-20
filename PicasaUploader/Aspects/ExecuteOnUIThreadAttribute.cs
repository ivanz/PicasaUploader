using System;
using System.Collections.Generic;
using System.Linq;
using PostSharp.Aspects;
using PicasaUploader.Services;

namespace PicasaUploader.Aspects
{
    [Serializable]
    public class ExecuteOnUIThreadAttribute : MethodInterceptionAspect
    {
        // As far as I can tell PostSharp doesn't support ctor dependency injection
        private static IUIDispatcher IUIDispatcher
        {
            get { return Program.UIDispatcher; }
        }

        public override void OnInvoke(MethodInterceptionArgs args)
        {
            IUIDispatcher.InvokeOnUIThread(args.Proceed);
        }
    }
}
