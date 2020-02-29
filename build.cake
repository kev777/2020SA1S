var target = Argument ("target", "Default");

Task("Default")
    .Does(() => {
        MSBuild("./ComidaRapida 1.1.0/cliente/cliente.sln");
    });

RunTarget(target);