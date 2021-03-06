﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.Silverlight.Phone.ServiceReference, version 3.7.0.0
// 
namespace PhoneMobileTracker.WcfMobileTracker {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WcfMobileTracker.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IService/DoWork", ReplyAction="http://tempuri.org/IService/DoWorkResponse")]
        System.IAsyncResult BeginDoWork(System.AsyncCallback callback, object asyncState);
        
        void EndDoWork(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IService/WriteGps", ReplyAction="http://tempuri.org/IService/WriteGpsResponse")]
        System.IAsyncResult BeginWriteGps(string userName, string password, string imei, int time, double lat, double lng, System.AsyncCallback callback, object asyncState);
        
        int EndWriteGps(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IService/UserExist", ReplyAction="http://tempuri.org/IService/UserExistResponse")]
        System.IAsyncResult BeginUserExist(string userName, string password, System.AsyncCallback callback, object asyncState);
        
        bool EndUserExist(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IService/CheckDevice", ReplyAction="http://tempuri.org/IService/CheckDeviceResponse")]
        System.IAsyncResult BeginCheckDevice(string userName, string password, string imei, System.AsyncCallback callback, object asyncState);
        
        bool EndCheckDevice(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : PhoneMobileTracker.WcfMobileTracker.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WriteGpsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public WriteGpsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public int Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserExistCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public UserExistCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public bool Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CheckDeviceCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public CheckDeviceCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public bool Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<PhoneMobileTracker.WcfMobileTracker.IService>, PhoneMobileTracker.WcfMobileTracker.IService {
        
        private BeginOperationDelegate onBeginDoWorkDelegate;
        
        private EndOperationDelegate onEndDoWorkDelegate;
        
        private System.Threading.SendOrPostCallback onDoWorkCompletedDelegate;
        
        private BeginOperationDelegate onBeginWriteGpsDelegate;
        
        private EndOperationDelegate onEndWriteGpsDelegate;
        
        private System.Threading.SendOrPostCallback onWriteGpsCompletedDelegate;
        
        private BeginOperationDelegate onBeginUserExistDelegate;
        
        private EndOperationDelegate onEndUserExistDelegate;
        
        private System.Threading.SendOrPostCallback onUserExistCompletedDelegate;
        
        private BeginOperationDelegate onBeginCheckDeviceDelegate;
        
        private EndOperationDelegate onEndCheckDeviceDelegate;
        
        private System.Threading.SendOrPostCallback onCheckDeviceCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Net.CookieContainer CookieContainer {
            get {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    return httpCookieContainerManager.CookieContainer;
                }
                else {
                    return null;
                }
            }
            set {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    httpCookieContainerManager.CookieContainer = value;
                }
                else {
                    throw new System.InvalidOperationException("Unable to set the CookieContainer. Please make sure the binding contains an HttpC" +
                            "ookieContainerBindingElement.");
                }
            }
        }
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> DoWorkCompleted;
        
        public event System.EventHandler<WriteGpsCompletedEventArgs> WriteGpsCompleted;
        
        public event System.EventHandler<UserExistCompletedEventArgs> UserExistCompleted;
        
        public event System.EventHandler<CheckDeviceCompletedEventArgs> CheckDeviceCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult PhoneMobileTracker.WcfMobileTracker.IService.BeginDoWork(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginDoWork(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        void PhoneMobileTracker.WcfMobileTracker.IService.EndDoWork(System.IAsyncResult result) {
            base.Channel.EndDoWork(result);
        }
        
        private System.IAsyncResult OnBeginDoWork(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((PhoneMobileTracker.WcfMobileTracker.IService)(this)).BeginDoWork(callback, asyncState);
        }
        
        private object[] OnEndDoWork(System.IAsyncResult result) {
            ((PhoneMobileTracker.WcfMobileTracker.IService)(this)).EndDoWork(result);
            return null;
        }
        
        private void OnDoWorkCompleted(object state) {
            if ((this.DoWorkCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.DoWorkCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void DoWorkAsync() {
            this.DoWorkAsync(null);
        }
        
        public void DoWorkAsync(object userState) {
            if ((this.onBeginDoWorkDelegate == null)) {
                this.onBeginDoWorkDelegate = new BeginOperationDelegate(this.OnBeginDoWork);
            }
            if ((this.onEndDoWorkDelegate == null)) {
                this.onEndDoWorkDelegate = new EndOperationDelegate(this.OnEndDoWork);
            }
            if ((this.onDoWorkCompletedDelegate == null)) {
                this.onDoWorkCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnDoWorkCompleted);
            }
            base.InvokeAsync(this.onBeginDoWorkDelegate, null, this.onEndDoWorkDelegate, this.onDoWorkCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult PhoneMobileTracker.WcfMobileTracker.IService.BeginWriteGps(string userName, string password, string imei, int time, double lat, double lng, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginWriteGps(userName, password, imei, time, lat, lng, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        int PhoneMobileTracker.WcfMobileTracker.IService.EndWriteGps(System.IAsyncResult result) {
            return base.Channel.EndWriteGps(result);
        }
        
        private System.IAsyncResult OnBeginWriteGps(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string userName = ((string)(inValues[0]));
            string password = ((string)(inValues[1]));
            string imei = ((string)(inValues[2]));
            int time = ((int)(inValues[3]));
            double lat = ((double)(inValues[4]));
            double lng = ((double)(inValues[5]));
            return ((PhoneMobileTracker.WcfMobileTracker.IService)(this)).BeginWriteGps(userName, password, imei, time, lat, lng, callback, asyncState);
        }
        
        private object[] OnEndWriteGps(System.IAsyncResult result) {
            int retVal = ((PhoneMobileTracker.WcfMobileTracker.IService)(this)).EndWriteGps(result);
            return new object[] {
                    retVal};
        }
        
        private void OnWriteGpsCompleted(object state) {
            if ((this.WriteGpsCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.WriteGpsCompleted(this, new WriteGpsCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void WriteGpsAsync(string userName, string password, string imei, int time, double lat, double lng) {
            this.WriteGpsAsync(userName, password, imei, time, lat, lng, null);
        }
        
        public void WriteGpsAsync(string userName, string password, string imei, int time, double lat, double lng, object userState) {
            if ((this.onBeginWriteGpsDelegate == null)) {
                this.onBeginWriteGpsDelegate = new BeginOperationDelegate(this.OnBeginWriteGps);
            }
            if ((this.onEndWriteGpsDelegate == null)) {
                this.onEndWriteGpsDelegate = new EndOperationDelegate(this.OnEndWriteGps);
            }
            if ((this.onWriteGpsCompletedDelegate == null)) {
                this.onWriteGpsCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnWriteGpsCompleted);
            }
            base.InvokeAsync(this.onBeginWriteGpsDelegate, new object[] {
                        userName,
                        password,
                        imei,
                        time,
                        lat,
                        lng}, this.onEndWriteGpsDelegate, this.onWriteGpsCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult PhoneMobileTracker.WcfMobileTracker.IService.BeginUserExist(string userName, string password, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginUserExist(userName, password, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        bool PhoneMobileTracker.WcfMobileTracker.IService.EndUserExist(System.IAsyncResult result) {
            return base.Channel.EndUserExist(result);
        }
        
        private System.IAsyncResult OnBeginUserExist(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string userName = ((string)(inValues[0]));
            string password = ((string)(inValues[1]));
            return ((PhoneMobileTracker.WcfMobileTracker.IService)(this)).BeginUserExist(userName, password, callback, asyncState);
        }
        
        private object[] OnEndUserExist(System.IAsyncResult result) {
            bool retVal = ((PhoneMobileTracker.WcfMobileTracker.IService)(this)).EndUserExist(result);
            return new object[] {
                    retVal};
        }
        
        private void OnUserExistCompleted(object state) {
            if ((this.UserExistCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.UserExistCompleted(this, new UserExistCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void UserExistAsync(string userName, string password) {
            this.UserExistAsync(userName, password, null);
        }
        
        public void UserExistAsync(string userName, string password, object userState) {
            if ((this.onBeginUserExistDelegate == null)) {
                this.onBeginUserExistDelegate = new BeginOperationDelegate(this.OnBeginUserExist);
            }
            if ((this.onEndUserExistDelegate == null)) {
                this.onEndUserExistDelegate = new EndOperationDelegate(this.OnEndUserExist);
            }
            if ((this.onUserExistCompletedDelegate == null)) {
                this.onUserExistCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnUserExistCompleted);
            }
            base.InvokeAsync(this.onBeginUserExistDelegate, new object[] {
                        userName,
                        password}, this.onEndUserExistDelegate, this.onUserExistCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult PhoneMobileTracker.WcfMobileTracker.IService.BeginCheckDevice(string userName, string password, string imei, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginCheckDevice(userName, password, imei, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        bool PhoneMobileTracker.WcfMobileTracker.IService.EndCheckDevice(System.IAsyncResult result) {
            return base.Channel.EndCheckDevice(result);
        }
        
        private System.IAsyncResult OnBeginCheckDevice(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string userName = ((string)(inValues[0]));
            string password = ((string)(inValues[1]));
            string imei = ((string)(inValues[2]));
            return ((PhoneMobileTracker.WcfMobileTracker.IService)(this)).BeginCheckDevice(userName, password, imei, callback, asyncState);
        }
        
        private object[] OnEndCheckDevice(System.IAsyncResult result) {
            bool retVal = ((PhoneMobileTracker.WcfMobileTracker.IService)(this)).EndCheckDevice(result);
            return new object[] {
                    retVal};
        }
        
        private void OnCheckDeviceCompleted(object state) {
            if ((this.CheckDeviceCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CheckDeviceCompleted(this, new CheckDeviceCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CheckDeviceAsync(string userName, string password, string imei) {
            this.CheckDeviceAsync(userName, password, imei, null);
        }
        
        public void CheckDeviceAsync(string userName, string password, string imei, object userState) {
            if ((this.onBeginCheckDeviceDelegate == null)) {
                this.onBeginCheckDeviceDelegate = new BeginOperationDelegate(this.OnBeginCheckDevice);
            }
            if ((this.onEndCheckDeviceDelegate == null)) {
                this.onEndCheckDeviceDelegate = new EndOperationDelegate(this.OnEndCheckDevice);
            }
            if ((this.onCheckDeviceCompletedDelegate == null)) {
                this.onCheckDeviceCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCheckDeviceCompleted);
            }
            base.InvokeAsync(this.onBeginCheckDeviceDelegate, new object[] {
                        userName,
                        password,
                        imei}, this.onEndCheckDeviceDelegate, this.onCheckDeviceCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(callback, asyncState);
        }
        
        private object[] OnEndOpen(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndOpen(result);
            return null;
        }
        
        private void OnOpenCompleted(object state) {
            if ((this.OpenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void OpenAsync() {
            this.OpenAsync(null);
        }
        
        public void OpenAsync(object userState) {
            if ((this.onBeginOpenDelegate == null)) {
                this.onBeginOpenDelegate = new BeginOperationDelegate(this.OnBeginOpen);
            }
            if ((this.onEndOpenDelegate == null)) {
                this.onEndOpenDelegate = new EndOperationDelegate(this.OnEndOpen);
            }
            if ((this.onOpenCompletedDelegate == null)) {
                this.onOpenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, null, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginClose(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginClose(callback, asyncState);
        }
        
        private object[] OnEndClose(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndClose(result);
            return null;
        }
        
        private void OnCloseCompleted(object state) {
            if ((this.CloseCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CloseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CloseAsync() {
            this.CloseAsync(null);
        }
        
        public void CloseAsync(object userState) {
            if ((this.onBeginCloseDelegate == null)) {
                this.onBeginCloseDelegate = new BeginOperationDelegate(this.OnBeginClose);
            }
            if ((this.onEndCloseDelegate == null)) {
                this.onEndCloseDelegate = new EndOperationDelegate(this.OnEndClose);
            }
            if ((this.onCloseCompletedDelegate == null)) {
                this.onCloseCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }
        
        protected override PhoneMobileTracker.WcfMobileTracker.IService CreateChannel() {
            return new ServiceClientChannel(this);
        }
        
        private class ServiceClientChannel : ChannelBase<PhoneMobileTracker.WcfMobileTracker.IService>, PhoneMobileTracker.WcfMobileTracker.IService {
            
            public ServiceClientChannel(System.ServiceModel.ClientBase<PhoneMobileTracker.WcfMobileTracker.IService> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginDoWork(System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[0];
                System.IAsyncResult _result = base.BeginInvoke("DoWork", _args, callback, asyncState);
                return _result;
            }
            
            public void EndDoWork(System.IAsyncResult result) {
                object[] _args = new object[0];
                base.EndInvoke("DoWork", _args, result);
            }
            
            public System.IAsyncResult BeginWriteGps(string userName, string password, string imei, int time, double lat, double lng, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[6];
                _args[0] = userName;
                _args[1] = password;
                _args[2] = imei;
                _args[3] = time;
                _args[4] = lat;
                _args[5] = lng;
                System.IAsyncResult _result = base.BeginInvoke("WriteGps", _args, callback, asyncState);
                return _result;
            }
            
            public int EndWriteGps(System.IAsyncResult result) {
                object[] _args = new object[0];
                int _result = ((int)(base.EndInvoke("WriteGps", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginUserExist(string userName, string password, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[2];
                _args[0] = userName;
                _args[1] = password;
                System.IAsyncResult _result = base.BeginInvoke("UserExist", _args, callback, asyncState);
                return _result;
            }
            
            public bool EndUserExist(System.IAsyncResult result) {
                object[] _args = new object[0];
                bool _result = ((bool)(base.EndInvoke("UserExist", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginCheckDevice(string userName, string password, string imei, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[3];
                _args[0] = userName;
                _args[1] = password;
                _args[2] = imei;
                System.IAsyncResult _result = base.BeginInvoke("CheckDevice", _args, callback, asyncState);
                return _result;
            }
            
            public bool EndCheckDevice(System.IAsyncResult result) {
                object[] _args = new object[0];
                bool _result = ((bool)(base.EndInvoke("CheckDevice", _args, result)));
                return _result;
            }
        }
    }
}
