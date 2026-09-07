globalThis.MonoGameWebHostConfiguration = {
    runtimeScriptUri: "./_framework/dotnet.js",
    hostExportsTypeName: "MGNamespace.HostExports",
    mainAssemblyName: "MGNamespace.dll"
};

await import("./monogame-web-host.js");
