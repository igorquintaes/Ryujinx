using Ryujinx.HLE.HOS.Ipc;
using Ryujinx.HLE.HOS.Kernel.Common;
using Ryujinx.HLE.HOS.Kernel.Threading;
using System;
using System.Collections.Generic;

namespace Ryujinx.HLE.HOS.Services.Friend
{
    class INotificationService : IpcService
    {
        private Dictionary<int, ServiceProcessRequest> _commands;

        public override IReadOnlyDictionary<int, ServiceProcessRequest> Commands => _commands;

        public INotificationService()
        {
            _commands = new Dictionary<int, ServiceProcessRequest>
            {
                { 0, GetEvent }
            };
        }

        public long GetEvent(ServiceCtx context)
        {
            KEvent Event = context.Device.System.AppletState.MessageEvent;

            if (context.Process.HandleTable.GenerateHandle(Event.ReadableEvent, out int handle) != KernelResult.Success)
            {
                throw new InvalidOperationException("Out of handles!");
            }

            context.Response.HandleDesc = IpcHandleDesc.MakeCopy(handle);

            return 0;
        }
    }
}
