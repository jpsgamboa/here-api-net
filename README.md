# Here API for .NET
.NET Standard wrapper around the [Here API](https://developer.here.com/documentation)

# What's already implemented:

[Routing Service](https://developer.here.com/documentation/routing/topics/resources.html):
- [x] [Calculate Route](https://developer.here.com/documentation/routing/topics/resource-calculate-route.html)
- [x] [Get Route](https://developer.here.com/documentation/routing/topics/resource-get-route.html#resource-get-route)
- [x] [Calculate Isoline](https://developer.here.com/documentation/routing/topics/resource-calculate-isoline.html#resource-calculate-isoline)
- [ ] [Calculate Matrix](https://developer.here.com/documentation/routing/topics/resource-calculate-matrix.html)

# Before trying it out:
All users of HERE APIs must obtain authentication and authorization credentials and provide them as values for the parameters app_id and app_code. The credentials are assigned per application. 

To obtain the credentials for an application, visit [plans](http://developer.here.com/plans) to register with HERE.

If you wish to explore the API, use the [API Explorer](https://developer.here.com/api-explorer).

# Usage:

Calculate a Route:
```c#
HereAPI.HereAPI.Register(appId, appCode, true);

            CalculateRouteRequest request = new CalculateRouteRequest()
            {
                RoutingMode = new RequestRoutingMode(RoutingType.Fastest, TransportModeType.Car),
                Waypoints = new WaypointParameter[]
                {
                    new GeoWaypointParameter(0, new GeoCoordinate(38.711428, -9.240167)),
                    new GeoWaypointParameter(1, new GeoCoordinate(38.857363, -9.165800))
                },
                Departure = new DateTime(2018, 05, 15, 19, 00, 00),

                RouteAttributes = new RouteAttributeType[] { RouteAttributeType.Shape, RouteAttributeType.Legs,
                    RouteAttributeType.Incidents, RouteAttributeType.Groups },

                LegAttributes = new RouteLegAttributeType[] { RouteLegAttributeType.Links },

                ManeuverAttributes = new ManeuverAttributeType[] { ManeuverAttributeType.Time, ManeuverAttributeType.TrafficTime,
                    ManeuverAttributeType.BaseTime, ManeuverAttributeType.Notes },

                InstructionFormat = InstructionFormatType.Text
            };

            CalculateRouteResponse calculateRoute = request.Get();

            Console.WriteLine(calculateRoute.Routes.First().Summary.Text);

```
