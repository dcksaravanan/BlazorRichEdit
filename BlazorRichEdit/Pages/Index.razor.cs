using BlazorRichEdit.Data;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRichEdit.Pages
{
    public partial class Index
    {
        bool PopupVisible { get; set; } = false;
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                var documentAsBase64 = "e1xydGYxXGRlZmYwe1xmb250dGJse1xmMCBDYWxpYnJpO319e1xjb2xvcnRibCA7XHJlZDB"
                + "cZ3JlZW4wXGJsdWUyNTUgO1xyZWQyNTVcZ3JlZW4yNTVcYmx1ZTI1NSA7fXtcKlxkZWZjaHAgXGZzMjJ9e1xzdHl"
                + "sZXNoZWV0IHtccWxcZnMyMiBOb3JtYWw7fXtcKlxjczFcZnMyMiBEZWZhdWx0IFBhcmFncmFwaCBGb250O317XCp"
                + "cY3MyXGZzMjJcY2YxIEh5cGVybGluazt9e1wqXHRzM1x0c3Jvd2RcZnMyMlxxbFx0c3ZlcnRhbHRcdHNjZWxsY2J"
                + "wYXQyXHRzY2VsbHBjdDBcY2x0eGxydGIgTm9ybWFsIFRhYmxlO319e1wqXGxpc3RvdmVycmlkZXRhYmxlfXtcaW5"
                + "mb31cbm91aWNvbXBhdFxzcGx5dHduaW5lXGh0bWF1dHNwXGV4cHNocnRuXHNwbHRwZ3BhclxkZWZ0YWI3MjBcc2V"
                + "jdGRcbWFyZ2xzeG4xNDQwXG1hcmdyc3huMTQ0MFxtYXJndHN4bjE0NDBcbWFyZ2JzeG4xNDQwXGhlYWRlcnk3MjB"
                + "cZm9vdGVyeTcyMFxwZ3dzeG4xMjI0MFxwZ2hzeG4xNTg0MFxjb2xzMVxjb2xzeDcyMFxwYXJkXHBsYWluXHFse1x"
                + "mczIyXGNmMFxjczEgRG9jdW1lbnQgdGV4dH1cZnMyMlxjZjBccGFyfQ==";

                await JSRuntime.InvokeVoidAsync("createRichEdit", "api/RichEdit/SaveDocument", documentAsBase64);
                await SendDotNetInstanceToJS();
            }
        }
        private async Task SendDotNetInstanceToJS()
        {
            var dotNetObjRef = DotNetObjectReference.Create(this);
            await JSRuntime.InvokeVoidAsync("sendDotNetInstanceToJS", dotNetObjRef);
        }
        [JSInvokable("ShowMacroList")]
        public Task ShowMacroList()
        {
            PopupVisible = true;
            StateHasChanged();
            return null;
        }
        IEnumerable<Macro> Values { get; set; }
        List<Macro> DataSource { get; set; } = new List<Macro>() { new Macro() { Name = "Macro 1" }, new Macro() { Name = "Macro 2" }, new Macro() { Name = "Macro 3" }, new Macro() { Name = "Macro 4" } };
    }

}