using Microsoft.JSInterop;
using System.Threading.Tasks;
using System;

public class ExampleJsInterop : IDisposable
{
    private readonly IJSRuntime jsRuntime;
    private DotNetObjectReference<HelloHelper> objRef;

    public ExampleJsInterop(IJSRuntime jsRuntime)
    {
        this.jsRuntime = jsRuntime;
    }

    IJSObjectReference jsmodule;
    public async ValueTask<string> CallHelloHelperSayHello(string name)
    {
        objRef = DotNetObjectReference.Create(new HelloHelper(name));
        jsmodule = await jsRuntime.InvokeAsync<IJSObjectReference>("import", "/_content/MyBlog.Shared/Interop.razor.js");
        return await jsmodule.InvokeAsync<string>("sayHello", objRef);
    }

    public void Dispose()
    {
        objRef?.Dispose();
    }
}