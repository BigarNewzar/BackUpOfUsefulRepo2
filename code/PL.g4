/*
Grammar for propositional logic
*/

grammar PL;

header
{
    package parser;
}

options
{
    language = Python3;
}

ATOM: ALPHANUMERIC+;
CONNECTIVE : '~' | '&' | '||' | '=>' | '<=>' ;
WS : [ \t\r\n]+ -> skip;

fragment ALPHANUMERIC: ALPHA | DIGIT ;
fragment ALPHA: '_' | SMALL_LETTER | CAPITAL_LETTER ;
fragment SMALL_LETTER: [a-z_];
fragment CAPITAL_LETTER: [A-Z];
fragment DIGIT: [0-9];
