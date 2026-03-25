Projektet her er lavet ud fra en beskrivelse fra dette link : https://code-maze.com/dependency-inversion-principle/ 

Koden er også udvidet, så der også arbejdes med Generics, Expressions og Reflections samt Self statiske metoder. ALt sammen er lavet på en god og overskuelig måde, så man let kan forstå principperne og koden i projektet.

Projektet,som er et simpelt C# konsol projekt, er struktureret på den måde, at det består af en Program.cs fil, som anvender en hel stribe *.cs filer. Alle *.cs filer er navngivet med et tal som den sidste 
karakter i filnavnet. Dette tal viser hvilke *.cs filer, der "hører sammen". 

Den eneste undtagelse fra denne regel er filen : PrintTools.cs som lever sit eget liv. Funktionere i denne fil er et godt eksemple på, hvor let det er at lave almene funktioner i C#, når man benytter sig af Generics 
og Refletion. De samme principper som Entity Frameork benytter sig af.  
