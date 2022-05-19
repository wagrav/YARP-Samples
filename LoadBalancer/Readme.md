#Exercise

1. Run app using `run.bat` file.
2. Visit pages:
- https://localhost:5041/PowerOfTwoChoices/
- https://localhost:5041/LeastRequests/
- https://localhost:5041/RoundRobin/
- https://localhost:5041/FirstAlphabetical/
- https://localhost:5041/Random/

Above routes use all natively supported load balancing policies built in YARP. By calling those request frequently you will notice that your requestes are handled by differnt endpoints. It can be noticed by url field in response body. 

E.G.

- url: "https://localhost:5041/anything/instance-id-1/by-Random/"
- url: "https://localhost:5041/anything/instance-id-5/by-FirstAlphabetical/"
- url: "https://localhost:5041/anything/instance-id-3/by-PowerOfTwoChoices/"

In reverse proxy config there are clusters dedicated for all those routes. Each cluster has got 5 registred destination instances to comunicate with.  

`instance-id-X` where X is an instance Id.  

## Read more

https://microsoft.github.io/reverse-proxy/articles/load-balancing.html