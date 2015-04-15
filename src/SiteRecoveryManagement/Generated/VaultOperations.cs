// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Hyak.Common;
using Microsoft.WindowsAzure.Management.RecoveryServices;
using Microsoft.WindowsAzure.Management.RecoveryServices.Models;

namespace Microsoft.WindowsAzure.Management.RecoveryServices
{
    /// <summary>
    /// Definition of vault operations for the Site Recovery extension.
    /// </summary>
    internal partial class VaultOperations : IServiceOperations<RecoveryServicesManagementClient>, IVaultOperations
    {
        /// <summary>
        /// Initializes a new instance of the VaultOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        internal VaultOperations(RecoveryServicesManagementClient client)
        {
            this._client = client;
        }
        
        private RecoveryServicesManagementClient _client;
        
        /// <summary>
        /// Gets a reference to the
        /// Microsoft.WindowsAzure.Management.RecoveryServices.RecoveryServicesManagementClient.
        /// </summary>
        public RecoveryServicesManagementClient Client
        {
            get { return this._client; }
        }
        
        /// <summary>
        /// Creates a vault
        /// </summary>
        /// <param name='cloudServiceName'>
        /// Required. The name of the cloud service containing the job
        /// collection.
        /// </param>
        /// <param name='vaultName'>
        /// Required. The name of the vault to create.
        /// </param>
        /// <param name='vaultCreationInput'>
        /// Required. Vault object to be created
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The response model for the Vm group object.
        /// </returns>
        public async Task<VaultCreateResponse> BeginCreatingAsync(string cloudServiceName, string vaultName, VaultCreateArgs vaultCreationInput, CancellationToken cancellationToken)
        {
            // Validate
            if (cloudServiceName == null)
            {
                throw new ArgumentNullException("cloudServiceName");
            }
            if (vaultName == null)
            {
                throw new ArgumentNullException("vaultName");
            }
            if (vaultCreationInput == null)
            {
                throw new ArgumentNullException("vaultCreationInput");
            }
            
            // Tracing
            bool shouldTrace = TracingAdapter.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = TracingAdapter.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("cloudServiceName", cloudServiceName);
                tracingParameters.Add("vaultName", vaultName);
                tracingParameters.Add("vaultCreationInput", vaultCreationInput);
                TracingAdapter.Enter(invocationId, this, "BeginCreatingAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "";
            if (this.Client.Credentials.SubscriptionId != null)
            {
                url = url + Uri.EscapeDataString(this.Client.Credentials.SubscriptionId);
            }
            url = url + "/cloudservices/";
            url = url + Uri.EscapeDataString(cloudServiceName);
            url = url + "/resources/";
            url = url + "WAHyperVRecoveryManager";
            url = url + "/";
            url = url + "HyperVRecoveryManagerVault";
            url = url + "/";
            url = url + Uri.EscapeDataString(vaultName);
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Put;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("Accept", "application/xml");
                httpRequest.Headers.Add("x-ms-version", "2013-03-01");
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Serialize Request
                string requestContent = null;
                XDocument requestDoc = new XDocument();
                
                XElement resourceElement = new XElement(XName.Get("Resource", "http://schemas.microsoft.com/windowsazure"));
                requestDoc.Add(resourceElement);
                
                if (vaultCreationInput.ResourceProviderNamespace != null)
                {
                    XElement resourceProviderNamespaceElement = new XElement(XName.Get("ResourceProviderNamespace", "http://schemas.microsoft.com/windowsazure"));
                    resourceProviderNamespaceElement.Value = vaultCreationInput.ResourceProviderNamespace;
                    resourceElement.Add(resourceProviderNamespaceElement);
                }
                
                if (vaultCreationInput.Type != null)
                {
                    XElement typeElement = new XElement(XName.Get("Type", "http://schemas.microsoft.com/windowsazure"));
                    typeElement.Value = vaultCreationInput.Type;
                    resourceElement.Add(typeElement);
                }
                
                if (vaultCreationInput.Name != null)
                {
                    XElement nameElement = new XElement(XName.Get("Name", "http://schemas.microsoft.com/windowsazure"));
                    nameElement.Value = vaultCreationInput.Name;
                    resourceElement.Add(nameElement);
                }
                
                if (vaultCreationInput.Plan != null)
                {
                    XElement planElement = new XElement(XName.Get("Plan", "http://schemas.microsoft.com/windowsazure"));
                    planElement.Value = vaultCreationInput.Plan;
                    resourceElement.Add(planElement);
                }
                
                if (vaultCreationInput.SchemaVersion != null)
                {
                    XElement schemaVersionElement = new XElement(XName.Get("SchemaVersion", "http://schemas.microsoft.com/windowsazure"));
                    schemaVersionElement.Value = vaultCreationInput.SchemaVersion;
                    resourceElement.Add(schemaVersionElement);
                }
                
                if (vaultCreationInput.ETag != null)
                {
                    XElement eTagElement = new XElement(XName.Get("ETag", "http://schemas.microsoft.com/windowsazure"));
                    eTagElement.Value = vaultCreationInput.ETag;
                    resourceElement.Add(eTagElement);
                }
                
                if (vaultCreationInput.Label != null)
                {
                    XElement labelElement = new XElement(XName.Get("Label", "http://schemas.microsoft.com/windowsazure"));
                    labelElement.Value = vaultCreationInput.Label;
                    resourceElement.Add(labelElement);
                }
                
                requestContent = requestDoc.ToString();
                httpRequest.Content = new StringContent(requestContent, Encoding.UTF8);
                httpRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/xml");
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        TracingAdapter.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        TracingAdapter.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.Accepted)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, requestContent, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
                        if (shouldTrace)
                        {
                            TracingAdapter.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    VaultCreateResponse result = null;
                    // Deserialize Response
                    result = new VaultCreateResponse();
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("ETag"))
                    {
                        result.ETag = httpResponse.Headers.GetValues("ETag").FirstOrDefault();
                    }
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        TracingAdapter.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
        
        /// <summary>
        /// Deletes a vault
        /// </summary>
        /// <param name='cloudServiceName'>
        /// Required. The name of the cloud service containing the job
        /// collection.
        /// </param>
        /// <param name='vaultName'>
        /// Required. The name of the vault to delete.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The response body contains the status of the specified asynchronous
        /// operation, indicating whether it has succeeded, is inprogress, or
        /// has failed. Note that this status is distinct from the HTTP status
        /// code returned for the Get Operation Status operation itself.  If
        /// the asynchronous operation succeeded, the response body includes
        /// the HTTP status code for the successful request.  If the
        /// asynchronous operation failed, the response body includes the HTTP
        /// status code for the failed request, and also includes error
        /// information regarding the failure.
        /// </returns>
        public async Task<RecoveryServicesOperationStatusResponse> BeginDeletingAsync(string cloudServiceName, string vaultName, CancellationToken cancellationToken)
        {
            // Validate
            if (cloudServiceName == null)
            {
                throw new ArgumentNullException("cloudServiceName");
            }
            if (vaultName == null)
            {
                throw new ArgumentNullException("vaultName");
            }
            
            // Tracing
            bool shouldTrace = TracingAdapter.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = TracingAdapter.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("cloudServiceName", cloudServiceName);
                tracingParameters.Add("vaultName", vaultName);
                TracingAdapter.Enter(invocationId, this, "BeginDeletingAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "";
            if (this.Client.Credentials.SubscriptionId != null)
            {
                url = url + Uri.EscapeDataString(this.Client.Credentials.SubscriptionId);
            }
            url = url + "/cloudservices/";
            url = url + Uri.EscapeDataString(cloudServiceName);
            url = url + "/resources/";
            url = url + "WAHyperVRecoveryManager";
            url = url + "/";
            url = url + "HyperVRecoveryManagerVault";
            url = url + "/";
            url = url + Uri.EscapeDataString(vaultName);
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Delete;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("Accept", "application/xml");
                httpRequest.Headers.Add("x-ms-version", "2013-03-01");
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        TracingAdapter.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        TracingAdapter.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.Accepted)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
                        if (shouldTrace)
                        {
                            TracingAdapter.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    RecoveryServicesOperationStatusResponse result = null;
                    // Deserialize Response
                    result = new RecoveryServicesOperationStatusResponse();
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        TracingAdapter.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
        
        /// <summary>
        /// Creates a vault
        /// </summary>
        /// <param name='cloudServiceName'>
        /// Required. The name of the cloud service containing the job
        /// collection.
        /// </param>
        /// <param name='vaultName'>
        /// Required. The name of the vault to create.
        /// </param>
        /// <param name='vaultCreationInput'>
        /// Required. Vault object to be created
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The response body contains the status of the specified asynchronous
        /// operation, indicating whether it has succeeded, is inprogress, or
        /// has failed. Note that this status is distinct from the HTTP status
        /// code returned for the Get Operation Status operation itself.  If
        /// the asynchronous operation succeeded, the response body includes
        /// the HTTP status code for the successful request.  If the
        /// asynchronous operation failed, the response body includes the HTTP
        /// status code for the failed request, and also includes error
        /// information regarding the failure.
        /// </returns>
        public async Task<RecoveryServicesOperationStatusResponse> CreateAsync(string cloudServiceName, string vaultName, VaultCreateArgs vaultCreationInput, CancellationToken cancellationToken)
        {
            RecoveryServicesManagementClient client = this.Client;
            bool shouldTrace = TracingAdapter.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = TracingAdapter.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("cloudServiceName", cloudServiceName);
                tracingParameters.Add("vaultName", vaultName);
                tracingParameters.Add("vaultCreationInput", vaultCreationInput);
                TracingAdapter.Enter(invocationId, this, "CreateAsync", tracingParameters);
            }
            
            cancellationToken.ThrowIfCancellationRequested();
            VaultCreateResponse response = await client.Vaults.BeginCreatingAsync(cloudServiceName, vaultName, vaultCreationInput, cancellationToken).ConfigureAwait(false);
            cancellationToken.ThrowIfCancellationRequested();
            RecoveryServicesOperationStatusResponse result = await client.GetOperationStatusAsync(response.RequestId, cancellationToken).ConfigureAwait(false);
            int delayInSeconds = 15;
            if (client.LongRunningOperationInitialTimeout >= 0)
            {
                delayInSeconds = client.LongRunningOperationInitialTimeout;
            }
            while ((result.Status != RecoveryServicesOperationStatus.InProgress) == false)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await TaskEx.Delay(delayInSeconds * 1000, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                result = await client.GetOperationStatusAsync(response.RequestId, cancellationToken).ConfigureAwait(false);
                delayInSeconds = 10;
                if (client.LongRunningOperationRetryTimeout >= 0)
                {
                    delayInSeconds = client.LongRunningOperationRetryTimeout;
                }
            }
            
            if (shouldTrace)
            {
                TracingAdapter.Exit(invocationId, result);
            }
            
            if (result.Status != RecoveryServicesOperationStatus.Succeeded)
            {
                if (result.Error != null)
                {
                    CloudException ex = new CloudException(result.Error.Code + " : " + result.Error.Message);
                    ex.Error = new CloudError();
                    ex.Error.Code = result.Error.Code;
                    ex.Error.Message = result.Error.Message;
                    if (shouldTrace)
                    {
                        TracingAdapter.Error(invocationId, ex);
                    }
                    throw ex;
                }
                else
                {
                    CloudException ex = new CloudException("");
                    if (shouldTrace)
                    {
                        TracingAdapter.Error(invocationId, ex);
                    }
                    throw ex;
                }
            }
            
            result.ETag = response.ETag;
            return result;
        }
        
        /// <summary>
        /// Deletes a vault
        /// </summary>
        /// <param name='cloudServiceName'>
        /// Required. The name of the cloud service containing the job
        /// collection.
        /// </param>
        /// <param name='vaultName'>
        /// Required. The name of the vault to delete.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The response body contains the status of the specified asynchronous
        /// operation, indicating whether it has succeeded, is inprogress, or
        /// has failed. Note that this status is distinct from the HTTP status
        /// code returned for the Get Operation Status operation itself.  If
        /// the asynchronous operation succeeded, the response body includes
        /// the HTTP status code for the successful request.  If the
        /// asynchronous operation failed, the response body includes the HTTP
        /// status code for the failed request, and also includes error
        /// information regarding the failure.
        /// </returns>
        public async Task<RecoveryServicesOperationStatusResponse> DeleteAsync(string cloudServiceName, string vaultName, CancellationToken cancellationToken)
        {
            RecoveryServicesManagementClient client = this.Client;
            bool shouldTrace = TracingAdapter.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = TracingAdapter.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("cloudServiceName", cloudServiceName);
                tracingParameters.Add("vaultName", vaultName);
                TracingAdapter.Enter(invocationId, this, "DeleteAsync", tracingParameters);
            }
            
            cancellationToken.ThrowIfCancellationRequested();
            RecoveryServicesOperationStatusResponse response = await client.Vaults.BeginDeletingAsync(cloudServiceName, vaultName, cancellationToken).ConfigureAwait(false);
            if (response.Status == RecoveryServicesOperationStatus.Succeeded)
            {
                return response;
            }
            cancellationToken.ThrowIfCancellationRequested();
            RecoveryServicesOperationStatusResponse result = await client.GetOperationStatusAsync(response.RequestId, cancellationToken).ConfigureAwait(false);
            int delayInSeconds = 15;
            if (client.LongRunningOperationInitialTimeout >= 0)
            {
                delayInSeconds = client.LongRunningOperationInitialTimeout;
            }
            while ((result.Status != RecoveryServicesOperationStatus.InProgress) == false)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await TaskEx.Delay(delayInSeconds * 1000, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                result = await client.GetOperationStatusAsync(response.RequestId, cancellationToken).ConfigureAwait(false);
                delayInSeconds = 10;
                if (client.LongRunningOperationRetryTimeout >= 0)
                {
                    delayInSeconds = client.LongRunningOperationRetryTimeout;
                }
            }
            
            if (shouldTrace)
            {
                TracingAdapter.Exit(invocationId, result);
            }
            
            if (result.Status != RecoveryServicesOperationStatus.Succeeded)
            {
                if (result.Error != null)
                {
                    CloudException ex = new CloudException(result.Error.Code + " : " + result.Error.Message);
                    ex.Error = new CloudError();
                    ex.Error.Code = result.Error.Code;
                    ex.Error.Message = result.Error.Message;
                    if (shouldTrace)
                    {
                        TracingAdapter.Error(invocationId, ex);
                    }
                    throw ex;
                }
                else
                {
                    CloudException ex = new CloudException("");
                    if (shouldTrace)
                    {
                        TracingAdapter.Error(invocationId, ex);
                    }
                    throw ex;
                }
            }
            
            return result;
        }
    }
}
