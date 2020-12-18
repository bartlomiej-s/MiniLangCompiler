// Section 1

%using CompilerSpace
%using ScannerSpace
%output=Parser.cs
%namespace ParserSpace
%parsertype Parser
%scanbasetype ScanBase
%tokentype Tokens

%union
{
public string  val;
public SyntaxTree st;
public List<SyntaxTree> list;
public Tokens tok;
public int lineBefore;
public int lineAfter;
}

%token prog, ifstmt, elsestmt, whilestmt, read, write, ret
%token inttype, doubletype, booltype, t, f
%token assign, bor, band, lor, land
%token equal, diff, larger, largere, smaller, smallere
%token plus, minus, mul, div, lneg, bneg
%token lbracket, rbracket, lcurlybracket, rcurlybracket, semicolon
%token id, numint, numdouble, str
%token eof

%type <st> Declaration
%type <st> Exp7
%type <st> Instruction, BlockInst, ExpInst, CondInst, LoopInst, InInst, OutInst, RetInst
%type <list> DeclarationPart, InstructionPart
%type <tok> Op2, Op3, Op4, Op5, Op6
// Other nonterminals: Exp1, Exp2, Exp3, Exp4, Exp5, Exp6, Op1, Type

%right elsestmt, noelsestmt

%% // Section 2

// 2)

Lang		: prog lcurlybracket Block rcurlybracket eof
		{
			YYACCEPT;

		}
		| error prog lcurlybracket Block rcurlybracket eof
		{
			SyntaxError("Wrong code before \'program\' block", $1.lineAfter);
			yyerrok();
			YYACCEPT;

		}
		| prog error lcurlybracket Block rcurlybracket eof
		{
			SyntaxError("Wrong code after \'program\' keyword", $2.lineAfter);
			yyerrok();
			YYACCEPT;
		}
		| prog lcurlybracket Block rcurlybracket error eof
		{
			SyntaxError("Wrong code after \'program\' block", $5.lineAfter);
			yyerrok();
			YYACCEPT;
		}
		| error prog error lcurlybracket Block rcurlybracket eof
		{
			SyntaxError("Wrong code before \'program\' block", $1.lineAfter);
			SyntaxError("Wrong code after \'program\' keyword", $3.lineAfter);
			yyerrok();
			YYACCEPT;
		}
		| error prog lcurlybracket Block rcurlybracket error eof
		{
			SyntaxError("Wrong code before \'program\' block", $1.lineAfter);
			SyntaxError("Wrong code after \'program\' block", $6.lineAfter);
			yyerrok();
			YYACCEPT;
		}
		| prog error lcurlybracket Block rcurlybracket error eof
		{
			SyntaxError("Wrong code after \'program\' keyword", $2.lineAfter);
			SyntaxError("Wrong code after \'program\' block", $6.lineAfter);
			yyerrok();
			YYACCEPT;
		}
		| error prog error lcurlybracket Block rcurlybracket error eof
		{
			SyntaxError("Wrong code before \'program\' block", $1.lineAfter);
			SyntaxError("Wrong code after \'program\' keyword", $3.lineAfter);
			SyntaxError("Wrong code after \'program\' block", $7.lineAfter);
			yyerrok();
			YYACCEPT;
		}
		| prog eof
		{
			SyntaxError("Unexpected symbol: EOF", $2.lineAfter);
			yyerrok();
			YYACCEPT;
		}
		| prog error eof
		{
			SyntaxError("Wrong code after \'program\' keyword", $2.lineAfter);
			SyntaxError("Unexpected symbol: EOF", $3.lineAfter);
			yyerrok();
			YYACCEPT;
		}
		| eof
		{
			SyntaxError("Unexpected symbol: EOF", $1.lineAfter);
			yyerrok();
			YYACCEPT;
		}
		| error eof
		{
			SyntaxError("Wrong code before \'program\' block", $1.lineAfter);
			SyntaxError("Unexpected symbol: EOF", $2.lineAfter);
			yyerrok();
			YYACCEPT;
		}
		;

Block		: DeclarationPart InstructionPart
		{
			List<SyntaxTree> list = $1;
			list.AddRange($2);
			Compiler.code = list;
		}
		| DeclarationPart error InstructionPart
		{
			List<SyntaxTree> list = $1;
			list.AddRange($3);
			Compiler.code = list;
			SyntaxError("Invalid instruction", $2.lineBefore);
			yyerrok();
		}
		;

DeclarationPart	: DeclarationPart Declaration
		{
			List<SyntaxTree> list = $1;
			if ($2 != null) list.Add($2);
			lastDeclPart = list;
			$$ = list;
		}
		|
		{
			List<SyntaxTree> list = new List<SyntaxTree>();
			lastDeclPart = list;
			$$ = list;
		}
		| DeclarationPart error Declaration
		{
			List<SyntaxTree> list = $1;
			if ($3 != null) list.Add($3);
			lastDeclPart = list;
			$$ = list;
			SyntaxError("Invalid declaration", $2.lineBefore);
			yyerrok();
		}
		| DeclarationPart eof
		{
			List<SyntaxTree> list = $1;
			lastDeclPart = list;
			$$ = list;
			Compiler.code = list;
			SyntaxError("Unexpected symbol: EOF", $2.lineAfter);
			yyerrok();
			YYACCEPT;
		}
		| DeclarationPart error eof
		{
			List<SyntaxTree> list = $1;
			lastDeclPart = list;
			$$ = list;
			Compiler.code = list;
			SyntaxError("Invalid declaration", $2.lineAfter);
			SyntaxError("Unexpected symbol: EOF", $3.lineAfter);
			yyerrok();
			YYACCEPT;
		}
		;

InstructionPart	: InstructionPart Instruction
		{
			List<SyntaxTree> list = $1;
			if ($2 != null) list.Add($2);
			lastInstPart = list;
			$$ = list;
		}
		|
		{
			List<SyntaxTree> list = new List<SyntaxTree>();
			lastInstPart = list;
			$$ = list;
		}
		| InstructionPart Instruction error 
		{
			List<SyntaxTree> list = $1;
			if ($2 != null) list.Add($2);
			lastInstPart = list;
			$$ = list;
			SyntaxError("Invalid instruction", $3.lineAfter);
			yyerrok();
		}
		| InstructionPart Instruction eof
		{
			List<SyntaxTree> list = $1;
			if ($2 != null) list.Add($2);
			lastInstPart = list;
			$$ = list;
			List<SyntaxTree> listEnd = lastDeclPart;
			listEnd.AddRange(list);
			Compiler.code = listEnd;
			SyntaxError("Unexpected symbol: EOF", $3.lineAfter);
			yyerrok();
			YYACCEPT;
		}
		| InstructionPart Instruction error eof
		{
			List<SyntaxTree> list = $1;
			if ($2 != null) list.Add($2);
			lastInstPart = list;
			$$ = list;
			List<SyntaxTree> listEnd = lastDeclPart;
			listEnd.AddRange(list);
			Compiler.code = listEnd;
			SyntaxError("Invalid instruction", $3.lineAfter);
			SyntaxError("Unexpected symbol: EOF", $4.lineAfter);
			yyerrok();
			YYACCEPT;
		}
		;

// 3)

Declaration	: Type id semicolon
		{
			Ident stId = new Ident($2.val, $2.lineAfter);
			Declaration st = new Declaration((TypeVal)$1.st, stId, $1.lineAfter);
			$$ = st;
		}
		;

Type		: inttype
		{
			TypeVal st = new TypeVal('i', $1.lineAfter);
			$$.st = st;
		}
		| doubletype
		{
			TypeVal st = new TypeVal('d', $1.lineAfter);
			$$.st = st;
		}
		| booltype
		{
			TypeVal st = new TypeVal('b', $1.lineAfter);
			$$.st = st;
		}
		;

// 4)

Instruction	: BlockInst
		{
			$$ = $1;
		}
		| ExpInst
		{
			$$ = $1;
		}
		| CondInst
		{
			$$ = $1;
		}
		| LoopInst
		{
			$$ = $1;
		}
		| InInst
		{
			$$ = $1;
		}
		| OutInst
		{
			$$ = $1;
		}
		| RetInst
		{
			$$ = $1;
		}
		;

BlockInst	: lcurlybracket InstructionPart rcurlybracket
		{
			BlockInst st = new BlockInst($2, $1.lineAfter);
			$$ = st;
		}
		;

ExpInst		: Exp7 semicolon
		{
			SyntaxTree st = $1;
			$$ = st;
		}
		;

CondInst	: ifstmt lbracket Exp7 rbracket Instruction elsestmt Instruction
		{
			CondInst st = new CondInst($3, $5, $7, $1.lineAfter);
			$$ = st;
		}
		| ifstmt lbracket Exp7 rbracket Instruction %prec noelsestmt
		{
			CondInst st = new CondInst($3, $5, null, $1.lineAfter);
			$$ = st;
		}
		;

LoopInst	: whilestmt lbracket Exp7 rbracket Instruction
		{
			LoopInst st = new LoopInst($3, $5, $1.lineAfter);
			$$ = st;
		}
		;

InInst		: read id semicolon
		{
			Ident stId = new Ident($2.val, $2.lineAfter);
			InInst st = new InInst(stId, $1.lineAfter);
			$$ = st;
		}
		;

OutInst		: write Exp7 semicolon
		{
			OutInst st = new OutInst($2, null, $1.lineAfter);
			$$ = st;
		}
		| write str semicolon
		{
			StringVal stStr = new StringVal($2.val, $2.lineAfter);
			OutInst st = new OutInst(null, stStr, $1.lineAfter);
			$$ = st;
		}
		;

RetInst		: ret semicolon
		{
			RetInst st = new RetInst($1.lineAfter);
			$$ = st;
		}
		;

// 5)

Exp7		: id assign Exp7
		{
			Ident stId = new Ident($1.val, $1.lineAfter);
			ExpInst st = new ExpInst(stId, Tokens.assign, $3, $1.lineAfter);
			$$ = st;
		}
		| Exp6
		{
			SyntaxTree st = $1.st;
			$$ = st;
		}
		;

Exp6		: Exp6 Op6 Exp5
		{
			ExpInst st = new ExpInst($1.st, $2, $3.st, $1.lineAfter);
			$$.st = st;
		}
		| Exp5
		{
			SyntaxTree st = $1.st;
			$$.st = st;
		}
		;

Op6		: lor
		{
			Tokens tok = Tokens.lor;
			$$ = tok;
		}
		| land
		{
			Tokens tok = Tokens.land;
			$$ = tok;
		}
		;

Exp5		: Exp5 Op5 Exp4
		{
			ExpInst st = new ExpInst($1.st, $2, $3.st, $1.lineAfter);
			$$.st = st;
		}
		| Exp4
		{
			SyntaxTree st = $1.st;
			$$.st = st;
		}
		;

Op5		: equal
		{
			Tokens tok = Tokens.equal;
			$$ = tok;
		}
		| diff
		{
			Tokens tok = Tokens.diff;
			$$ = tok;
		}
		| larger
		{
			Tokens tok = Tokens.larger;
			$$ = tok;
		}
		| largere
		{
			Tokens tok = Tokens.largere;
			$$ = tok;
		}
		| smaller
		{
			Tokens tok = Tokens.smaller;
			$$ = tok;
		}
		| smallere
		{
			Tokens tok = Tokens.smallere;
			$$ = tok;
		}
		;

Exp4		: Exp4 Op4 Exp3
		{
			ExpInst st = new ExpInst($1.st, $2, $3.st, $1.lineAfter);
			$$.st = st;
		}
		| Exp3
		{
			SyntaxTree st = $1.st;
			$$.st = st;
		}
		;

Op4		: plus
		{
			Tokens tok = Tokens.plus;
			$$ = tok;
		}
		| minus
		{
			Tokens tok = Tokens.minus;
			$$ = tok;
		}
		;

Exp3		: Exp3 Op3 Exp2
		{
			ExpInst st = new ExpInst($1.st, $2, $3.st, $1.lineAfter);
			$$.st = st;
		}
		| Exp2
		{
			SyntaxTree st = $1.st;
			$$.st = st;
		}
		;

Op3		: mul
		{
			Tokens tok = Tokens.mul;
			$$ = tok;
		}
		| div
		{
			Tokens tok = Tokens.div;
			$$ = tok;
		}
		;

Exp2		: Exp2 Op2 Exp1
		{
			ExpInst st = new ExpInst($1.st, $2, $3.st, $1.lineAfter);
			$$.st = st;
		}
		| Exp1
		{
			SyntaxTree st = $1.st;
		}
		;

Op2		: bor
		{
			Tokens tok = Tokens.bor;
			$$ = tok;
		}
		| band
		{
			Tokens tok = Tokens.band;
			$$ = tok;
		}
		;

Exp1		: Op1 Exp1
		{
			ExpInst st = new ExpInst(null, $1.tok, $2.st, $1.lineAfter);
			$$.st = st;
		}
		| id
		{
			Ident st = new Ident($1.val, $1.lineAfter);
			$$.st = st;
		}
		| numint
		{
			IntVal st = new IntVal(int.Parse($1.val), $1.lineAfter);
			$$.st = st;
		}
		| numdouble
		{
			DoubleVal st = new DoubleVal(double.Parse($1.val, CultureInfo.InvariantCulture), $1.lineAfter);
			$$.st = st;
		}
		| t
		{
			BoolVal st = new BoolVal(true, $1.lineAfter);
			$$.st = st;
		}
		| f
		{
			BoolVal st = new BoolVal(false, $1.lineAfter);
			$$.st = st;
		}
		| lbracket Exp7 rbracket
		{
			SyntaxTree st = $2;
			$$.st = st;
		}
		;

Op1		: minus
		{
			Tokens tok = Tokens.minus;
			$$.tok = tok;
		}
		| bneg
		{
			Tokens tok = Tokens.bneg;
			$$.tok = tok;
		}
		| lneg
		{
			Tokens tok = Tokens.lneg;
			$$.tok = tok;
		}
		| lbracket inttype rbracket
		{
			Tokens tok = Tokens.inttype;
			$$.tok = tok;
		}
		| lbracket doubletype rbracket
		{
			Tokens tok = Tokens.doubletype;
			$$.tok = tok;
		}
		;

%% // Section 3

public static List<SyntaxTree> lastInstPart  = new List<SyntaxTree>();
public static List<SyntaxTree> lastDeclPart  = new List<SyntaxTree>();

public Parser(Scanner scnr) : base(scnr) { }

private void SyntaxError(string msg, int line)
{
	Compiler.errors++;
	if (msg != "") msg += " ";
	Compiler.SaveError(msg, ErrorType.Syntax, line, msg=="" ? true : false);
}