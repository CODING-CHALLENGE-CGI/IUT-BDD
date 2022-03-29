SELECT
c.Name
FROM Characters c
INNER JOIN CharacterFriends cf
ON c.Id = cf.CharacterId

