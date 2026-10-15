# crdt-notes

Demonstra edição concorrente e convergência de uma nota com LWW-register.

## Desktop

```sh
dotnet run --project CrdtNotes.Desktop/CrdtNotes.Desktop.csproj
```

## Browser

Requer o workload wasm-tools do .NET 10.

```sh
dotnet run --project CrdtNotes.Browser/CrdtNotes.Browser.csproj
```

## Exemplo

Edite as duas réplicas e sincronize para aplicar o desempate por relógio lógico e réplica.
