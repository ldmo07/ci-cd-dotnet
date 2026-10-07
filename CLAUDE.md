# CLAUDE.md

Repo independiente (remoto `github.com/ldmo07/-ci-cd-dotnet`, con guion inicial), clonado dentro de `CI-CD/` pero ignorado por el repo raíz. Se commitea y pushea desde esta carpeta.

- App: minimal API en `Program.cs` (rutas `/`, `/products`, `/personas`), proyecto `example.csproj` (net8.0). No hay tests; la verificación es `docker build` + `curl`.
- CORS está habilitado a propósito: `ci-cd-react` (`:8084`) llama a `/personas` desde el navegador. No quitarlo sin ajustar el front.
- `Jenkinsfile`: copia de `templates/Jenkinsfile.template` del repo raíz. Solo editar `APP_NAME` (`dotnet-example`), `HOST_PORT` (`8083`), `CONTAINER_PORT` (`8080`; es el puerto del contenedor, no del host).
- Push a `main` => Jenkins despliega en ~1–2 min. Un build roto conserva el contenedor anterior.
- `.gitattributes` fuerza LF; CRLF en el `Jenkinsfile` rompe el pipeline.
- No agregar GitHub Actions: solo Jenkins hace CI/CD.
