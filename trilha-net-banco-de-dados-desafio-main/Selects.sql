use [Filmes];

--1
select Nome, Ano from [Filmes];

--2
select Nome, Ano from [Filmes] order by Ano asc;

--3
select Nome, Ano, Duracao from [Filmes] where nome like '%de volta para o futuro%';

--4
select Nome, Ano, Duracao from [Filmes] where ano = 1997;

--5
select Nome, Ano, Duracao from [Filmes] where ano > 2000;

--6
select Nome, Ano, Duracao from [Filmes] where Duracao > 100 and Duracao < 150 order by Duracao;

--7
select Ano, count(*) from [Filmes] group by Ano order by count(*) desc;

--8
select PrimeiroNome, UltimoNome from [Atores] where Genero = 'M'

--9
select PrimeiroNome, UltimoNome from [Atores] where Genero = 'F' order by PrimeiroNome

--10
select [Filmes].Nome, [Generos].Genero from [Filmes]
inner join [FilmesGenero] on [Filmes].Id = [FilmesGenero].IdFilme
inner join [Generos] on [FilmesGenero].IdGenero = [Generos].Id

--11
select [Filmes].Nome, [Generos].Genero from [Filmes]
inner join [FilmesGenero] on [Filmes].Id = [FilmesGenero].IdFilme
inner join [Generos] on [FilmesGenero].IdGenero = [Generos].Id
where [Generos].Genero = 'Mistério'

--12
select [Filmes].Nome, [Atores].PrimeiroNome, [Atores].UltimoNome, [ElencoFilme].Papel
from [Filmes]
inner join [ElencoFilme] on [Filmes].Id = [ElencoFilme].IdFilme
inner join [Atores] on [ElencoFilme].IdAtor = [Atores].Id;