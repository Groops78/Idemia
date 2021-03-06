﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Idemia.MicrochipMachine.BackEnd {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="BackEnd.IBackendService")]
    public interface IBackendService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBackendService/GetRequests", ReplyAction="http://tempuri.org/IBackendService/GetRequestsResponse")]
        Idemia.Common.Entities.Request[] GetRequests();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBackendService/GetRequests", ReplyAction="http://tempuri.org/IBackendService/GetRequestsResponse")]
        System.Threading.Tasks.Task<Idemia.Common.Entities.Request[]> GetRequestsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBackendService/GetRequestStatuses", ReplyAction="http://tempuri.org/IBackendService/GetRequestStatusesResponse")]
        Idemia.Common.Entities.RequestStatus[] GetRequestStatuses();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBackendService/GetRequestStatuses", ReplyAction="http://tempuri.org/IBackendService/GetRequestStatusesResponse")]
        System.Threading.Tasks.Task<Idemia.Common.Entities.RequestStatus[]> GetRequestStatusesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBackendService/SaveRequest", ReplyAction="http://tempuri.org/IBackendService/SaveRequestResponse")]
        string SaveRequest(Idemia.Common.Entities.Request request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBackendService/SaveRequest", ReplyAction="http://tempuri.org/IBackendService/SaveRequestResponse")]
        System.Threading.Tasks.Task<string> SaveRequestAsync(Idemia.Common.Entities.Request request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBackendService/GetNextRequest", ReplyAction="http://tempuri.org/IBackendService/GetNextRequestResponse")]
        Idemia.Common.Entities.Request GetNextRequest();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBackendService/GetNextRequest", ReplyAction="http://tempuri.org/IBackendService/GetNextRequestResponse")]
        System.Threading.Tasks.Task<Idemia.Common.Entities.Request> GetNextRequestAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBackendService/TransitionRequest", ReplyAction="http://tempuri.org/IBackendService/TransitionRequestResponse")]
        string TransitionRequest(string id, string statusId, string notifyCustomer, string notifyManager);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBackendService/TransitionRequest", ReplyAction="http://tempuri.org/IBackendService/TransitionRequestResponse")]
        System.Threading.Tasks.Task<string> TransitionRequestAsync(string id, string statusId, string notifyCustomer, string notifyManager);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBackendService/GetFactoryStats", ReplyAction="http://tempuri.org/IBackendService/GetFactoryStatsResponse")]
        Idemia.Common.Entities.FactoryStatistic[] GetFactoryStats(string from, string to);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBackendService/GetFactoryStats", ReplyAction="http://tempuri.org/IBackendService/GetFactoryStatsResponse")]
        System.Threading.Tasks.Task<Idemia.Common.Entities.FactoryStatistic[]> GetFactoryStatsAsync(string from, string to);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBackendService/ClearInProgress", ReplyAction="http://tempuri.org/IBackendService/ClearInProgressResponse")]
        void ClearInProgress();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBackendService/ClearInProgress", ReplyAction="http://tempuri.org/IBackendService/ClearInProgressResponse")]
        System.Threading.Tasks.Task ClearInProgressAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IBackendServiceChannel : Idemia.MicrochipMachine.BackEnd.IBackendService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BackendServiceClient : System.ServiceModel.ClientBase<Idemia.MicrochipMachine.BackEnd.IBackendService>, Idemia.MicrochipMachine.BackEnd.IBackendService {
        
        public BackendServiceClient() {
        }
        
        public BackendServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BackendServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BackendServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BackendServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Idemia.Common.Entities.Request[] GetRequests() {
            return base.Channel.GetRequests();
        }
        
        public System.Threading.Tasks.Task<Idemia.Common.Entities.Request[]> GetRequestsAsync() {
            return base.Channel.GetRequestsAsync();
        }
        
        public Idemia.Common.Entities.RequestStatus[] GetRequestStatuses() {
            return base.Channel.GetRequestStatuses();
        }
        
        public System.Threading.Tasks.Task<Idemia.Common.Entities.RequestStatus[]> GetRequestStatusesAsync() {
            return base.Channel.GetRequestStatusesAsync();
        }
        
        public string SaveRequest(Idemia.Common.Entities.Request request) {
            return base.Channel.SaveRequest(request);
        }
        
        public System.Threading.Tasks.Task<string> SaveRequestAsync(Idemia.Common.Entities.Request request) {
            return base.Channel.SaveRequestAsync(request);
        }
        
        public Idemia.Common.Entities.Request GetNextRequest() {
            return base.Channel.GetNextRequest();
        }
        
        public System.Threading.Tasks.Task<Idemia.Common.Entities.Request> GetNextRequestAsync() {
            return base.Channel.GetNextRequestAsync();
        }
        
        public string TransitionRequest(string id, string statusId, string notifyCustomer, string notifyManager) {
            return base.Channel.TransitionRequest(id, statusId, notifyCustomer, notifyManager);
        }
        
        public System.Threading.Tasks.Task<string> TransitionRequestAsync(string id, string statusId, string notifyCustomer, string notifyManager) {
            return base.Channel.TransitionRequestAsync(id, statusId, notifyCustomer, notifyManager);
        }
        
        public Idemia.Common.Entities.FactoryStatistic[] GetFactoryStats(string from, string to) {
            return base.Channel.GetFactoryStats(from, to);
        }
        
        public System.Threading.Tasks.Task<Idemia.Common.Entities.FactoryStatistic[]> GetFactoryStatsAsync(string from, string to) {
            return base.Channel.GetFactoryStatsAsync(from, to);
        }
        
        public void ClearInProgress() {
            base.Channel.ClearInProgress();
        }
        
        public System.Threading.Tasks.Task ClearInProgressAsync() {
            return base.Channel.ClearInProgressAsync();
        }
    }
}
