SELECT c.Name,p.Name AS HomePlanetName 
FROM Characters c
Left Join Planets p
ON p.ID = HomePlanetID;