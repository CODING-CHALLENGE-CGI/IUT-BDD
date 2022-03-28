SELECT
c.Name,
c.Discriminator,
ce.EpisodeId

FROM Characters c
INNER JOIN CharacterEpisodes ce
ON c.Id = ce.CharacterId
Inner JOIN Episodes e
ON ce.EpisodeId = e.Id
Group by c.Name, 
c.Discriminator,
e.ID
HAVING ce.EpisodeId = 5;