SELECT
c.Name, cb.Name
FROM Characters c
INNER JOIN CharacterFriends cf
ON c.Id = cf.CharacterId
Inner JOIN Characters cb
ON cb.ID = cf.
INNER JOIN Planets p
ON p.ID = c.HomePlanetId
Where cb.Name ='Luke Skywalker'
And p.Name = 'Alderaan'