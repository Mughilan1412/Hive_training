intall virtual box, install kubectl, install minikube, set up environmental variable path

open a new folder:
inside it command:
helm create dotnet-sample-app
#move_files
#to check
cd ..
helm template dotnet-sample-app ./dotnet-sample-app
#solve the errors if comes
#after files are perfect
minikube addons enable ingress
kubectl get pods -n ingress-nginx
minikube ip
#minikube_ip dotnet.local in hosts file
#helm install <release-name> <chart-path>
helm install dotnetapp ./dotnet-sample-app
#If you already installed it once and are just making changes, use upgrade:
helm upgrade dotnetapp ./mughil-helm-dotnet-app
helm list
helm uninstall dotnettapp

#note:
service is in ClusterIP
only ingress exposes service
if we run nginx-ingress in aws it will automatically run in expose mode "load balancer"
if you run nginx-ingress in minikube it runs in NodePort
here node is nothing but minikube
so we are setting minikube_ip dotnet.local in hosts file
if you ask by directly typing minikube ip on browser I can access the website right? ans: No, because you ingress rule expect a dotnet.local header so we are mapping the http://dotnet.local(i.e.,dotnet.local) to minikube_ip in hosts file.