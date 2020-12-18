// Section 1

%using CompilerSpace;
%using ParserSpace; 
%namespace ScannerSpace
%visibility public
%scannertype Scanner
%scanbasetype ScanBase
%tokentype Tokens

%option codePage:65001 out:Scanner.cs

%{
%}

ID [A-Za-z][A-Za-z0-9]*
NUMINT 0|[1-9][0-9]*
NUMDOUBLE (0|[1-9][0-9]*)\.[0-9]*
STRING \"([^"\n\\]|\\.)*\"
COMMENT \/\/[^\n]+\n
DELIMITER [ \t]
NL \r\n|\n|\r

%% // Section 2
%{
	yylval.lineBefore=lineno;
	yylval.lineAfter=lineno;
%}

"program"	{ return (int)Tokens.prog; }
"if"		{ return (int)Tokens.ifstmt; }
"else"		{ return (int)Tokens.elsestmt; }
"while"		{ return (int)Tokens.whilestmt; }
"read"		{ return (int)Tokens.read; }
"write"		{ return (int)Tokens.write; }
"return"	{ return (int)Tokens.ret; }
"int"		{ return (int)Tokens.inttype; }
"double"	{ return (int)Tokens.doubletype; }
"bool"		{ return (int)Tokens.booltype; }
"true"		{ return (int)Tokens.t; }
"false"		{ return (int)Tokens.f; }
"="		{ return (int)Tokens.assign; }
"|"		{ return (int)Tokens.bor; }
"&"		{ return (int)Tokens.band; }
"||"		{ return (int)Tokens.lor; }
"&&"		{ return (int)Tokens.land; }
"=="		{ return (int)Tokens.equal; }
"!="		{ return (int)Tokens.diff; }
">"		{ return (int)Tokens.larger; }
">="		{ return (int)Tokens.largere; }
"<"		{ return (int)Tokens.smaller; }
"<="		{ return (int)Tokens.smallere; }
"+"		{ return (int)Tokens.plus; }
"-"		{ return (int)Tokens.minus; }
"*"		{ return (int)Tokens.mul; }
"/"		{ return (int)Tokens.div; }
"!"		{ return (int)Tokens.lneg; }
"~"		{ return (int)Tokens.bneg; }
"("		{ return (int)Tokens.lbracket; }
")"		{ return (int)Tokens.rbracket; }
"{"		{ return (int)Tokens.lcurlybracket; }
"}"		{ return (int)Tokens.rcurlybracket; }
";"		{ return (int)Tokens.semicolon; }
{ID}		{ yylval.val=yytext; return (int)Tokens.id; }
{NUMINT}	{ yylval.val=yytext; return (int)Tokens.numint; }
{NUMDOUBLE}	{ yylval.val=yytext; return (int)Tokens.numdouble; }
{STRING}	{ yylval.val=yytext; return (int)Tokens.str; }
{COMMENT}	{ lineno++; }
{DELIMITER}	{ }
{NL}		{ lineno++; }
<<EOF>>       	{ return (int)Tokens.eof; }
.		{ LexError(yytext, lineno); }

%{
	yylval.lineAfter=lineno;
%}

%% // Section 3

public static int lineno=1;

private void LexError(string word, int line)
{
	Compiler.errors++;
	Compiler.SaveError("Wrong token: " + word, ErrorType.Lexical, line);
}