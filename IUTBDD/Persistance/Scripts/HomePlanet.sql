SELECT c.Name,(SELECT Name FROM Planets WHERE ID = c.HomeplanetId) AS HomePlanetName 
FROM Characters c;