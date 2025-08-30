{{/*
Expand the name of the chart.
*/}}
{{- define "dotnet-sample-app.name" -}}
{{ .Chart.Name }}
{{- end }}

{{/*
Create a fully qualified app name.
*/}}
{{- define "dotnet-sample-app.fullname" -}}
{{ include "dotnet-sample-app.name" . }}
{{- end }}

{{/*
Common labels
*/}}
{{- define "dotnet-sample-app.labels" -}}
app.kubernetes.io/name: {{ include "dotnet-sample-app.name" . }}
app.kubernetes.io/instance: {{ .Release.Name }}
app.kubernetes.io/version: {{ .Chart.AppVersion }}
app.kubernetes.io/managed-by: {{ .Release.Service }}
{{- end }}
