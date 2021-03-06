// This code was generated by the Gardens Point Parser Generator
// Copyright (c) Wayne Kelly, John Gough, QUT 2005-2014
// (see accompanying GPPGcopyright.rtf)

// GPPG version 1.5.2
// Machine:  DESKTOP-4SM9IRK
// DateTime: 30.06.2020 23:39:11
// UserName: Bartek
// Input file <.\files\kompilator.y - 30.06.2020 23:34:29>

// options: lines gplex

using System;
using System.Collections.Generic;
using System.CodeDom.Compiler;
using System.Globalization;
using System.Text;
using QUT.Gppg;
using CompilerSpace;
using ScannerSpace;

namespace ParserSpace
{
public enum Tokens {error=2,EOF=3,prog=4,ifstmt=5,elsestmt=6,
    whilestmt=7,read=8,write=9,ret=10,inttype=11,doubletype=12,
    booltype=13,t=14,f=15,assign=16,bor=17,band=18,
    lor=19,land=20,equal=21,diff=22,larger=23,largere=24,
    smaller=25,smallere=26,plus=27,minus=28,mul=29,div=30,
    lneg=31,bneg=32,lbracket=33,rbracket=34,lcurlybracket=35,rcurlybracket=36,
    semicolon=37,id=38,numint=39,numdouble=40,str=41,eof=42,
    noelsestmt=43};

public struct ValueType
#line 12 ".\files\kompilator.y"
{
public string  val;
public SyntaxTree st;
public List<SyntaxTree> list;
public Tokens tok;
public int lineBefore;
public int lineAfter;
}
#line default
// Abstract base class for GPLEX scanners
[GeneratedCodeAttribute( "Gardens Point Parser Generator", "1.5.2")]
public abstract class ScanBase : AbstractScanner<ValueType,LexLocation> {
  private LexLocation __yylloc = new LexLocation();
  public override LexLocation yylloc { get { return __yylloc; } set { __yylloc = value; } }
  protected virtual bool yywrap() { return true; }
}

// Utility class for encapsulating token information
[GeneratedCodeAttribute( "Gardens Point Parser Generator", "1.5.2")]
public class ScanObj {
  public int token;
  public ValueType yylval;
  public LexLocation yylloc;
  public ScanObj( int t, ValueType val, LexLocation loc ) {
    this.token = t; this.yylval = val; this.yylloc = loc;
  }
}

[GeneratedCodeAttribute( "Gardens Point Parser Generator", "1.5.2")]
public class Parser: ShiftReduceParser<ValueType, LexLocation>
{
#pragma warning disable 649
  private static Dictionary<int, string> aliases;
#pragma warning restore 649
  private static Rule[] rules = new Rule[84];
  private static State[] states = new State[138];
  private static string[] nonTerms = new string[] {
      "Declaration", "Exp7", "Instruction", "BlockInst", "ExpInst", "CondInst", 
      "LoopInst", "InInst", "OutInst", "RetInst", "DeclarationPart", "InstructionPart", 
      "Op2", "Op3", "Op4", "Op5", "Op6", "Lang", "$accept", "Block", "Type", 
      "Exp6", "Exp5", "Exp4", "Exp3", "Exp2", "Exp1", "Op1", };

  static Parser() {
    states[0] = new State(new int[]{4,3,2,121,42,137},new int[]{-18,1});
    states[1] = new State(new int[]{3,2});
    states[2] = new State(-1);
    states[3] = new State(new int[]{35,4,2,112,42,120});
    states[4] = new State(-17,new int[]{-20,5,-11,10});
    states[5] = new State(new int[]{36,6});
    states[6] = new State(new int[]{42,7,2,8});
    states[7] = new State(-2);
    states[8] = new State(new int[]{42,9});
    states[9] = new State(-5);
    states[10] = new State(new int[]{2,101,42,111,11,108,12,109,13,110,35,-22,38,-22,28,-22,32,-22,31,-22,33,-22,39,-22,40,-22,14,-22,15,-22,5,-22,7,-22,8,-22,9,-22,10,-22,36,-22},new int[]{-12,11,-1,100,-21,105});
    states[11] = new State(new int[]{35,17,38,23,28,39,32,40,31,41,33,42,39,66,40,67,14,68,15,69,5,74,7,82,8,88,9,92,10,98,36,-14},new int[]{-3,12,-4,16,-5,20,-2,21,-22,26,-23,49,-24,56,-25,59,-26,62,-27,65,-28,37,-6,73,-7,81,-8,87,-9,91,-10,97});
    states[12] = new State(new int[]{2,13,42,15,35,-21,38,-21,28,-21,32,-21,31,-21,33,-21,39,-21,40,-21,14,-21,15,-21,5,-21,7,-21,8,-21,9,-21,10,-21,36,-21});
    states[13] = new State(new int[]{42,14,35,-23,38,-23,28,-23,32,-23,31,-23,33,-23,39,-23,40,-23,14,-23,15,-23,5,-23,7,-23,8,-23,9,-23,10,-23,36,-23});
    states[14] = new State(-25);
    states[15] = new State(-24);
    states[16] = new State(-30);
    states[17] = new State(-22,new int[]{-12,18});
    states[18] = new State(new int[]{36,19,35,17,38,23,28,39,32,40,31,41,33,42,39,66,40,67,14,68,15,69,5,74,7,82,8,88,9,92,10,98},new int[]{-3,12,-4,16,-5,20,-2,21,-22,26,-23,49,-24,56,-25,59,-26,62,-27,65,-28,37,-6,73,-7,81,-8,87,-9,91,-10,97});
    states[19] = new State(-37);
    states[20] = new State(-31);
    states[21] = new State(new int[]{37,22});
    states[22] = new State(-38);
    states[23] = new State(new int[]{16,24,17,-73,18,-73,29,-73,30,-73,27,-73,28,-73,21,-73,22,-73,23,-73,24,-73,25,-73,26,-73,19,-73,20,-73,37,-73,34,-73});
    states[24] = new State(new int[]{38,23,28,39,32,40,31,41,33,42,39,66,40,67,14,68,15,69},new int[]{-2,25,-22,26,-23,49,-24,56,-25,59,-26,62,-27,65,-28,37});
    states[25] = new State(-46);
    states[26] = new State(new int[]{19,71,20,72,37,-47,34,-47},new int[]{-17,27});
    states[27] = new State(new int[]{28,39,32,40,31,41,33,42,38,70,39,66,40,67,14,68,15,69},new int[]{-23,28,-24,56,-25,59,-26,62,-27,65,-28,37});
    states[28] = new State(new int[]{21,50,22,51,23,52,24,53,25,54,26,55,19,-48,20,-48,37,-48,34,-48},new int[]{-16,29});
    states[29] = new State(new int[]{28,39,32,40,31,41,33,42,38,70,39,66,40,67,14,68,15,69},new int[]{-24,30,-25,59,-26,62,-27,65,-28,37});
    states[30] = new State(new int[]{27,57,28,58,21,-52,22,-52,23,-52,24,-52,25,-52,26,-52,19,-52,20,-52,37,-52,34,-52},new int[]{-15,31});
    states[31] = new State(new int[]{28,39,32,40,31,41,33,42,38,70,39,66,40,67,14,68,15,69},new int[]{-25,32,-26,62,-27,65,-28,37});
    states[32] = new State(new int[]{29,60,30,61,27,-60,28,-60,21,-60,22,-60,23,-60,24,-60,25,-60,26,-60,19,-60,20,-60,37,-60,34,-60},new int[]{-14,33});
    states[33] = new State(new int[]{28,39,32,40,31,41,33,42,38,70,39,66,40,67,14,68,15,69},new int[]{-26,34,-27,65,-28,37});
    states[34] = new State(new int[]{17,63,18,64,29,-64,30,-64,27,-64,28,-64,21,-64,22,-64,23,-64,24,-64,25,-64,26,-64,19,-64,20,-64,37,-64,34,-64},new int[]{-13,35});
    states[35] = new State(new int[]{28,39,32,40,31,41,33,42,38,70,39,66,40,67,14,68,15,69},new int[]{-27,36,-28,37});
    states[36] = new State(-68);
    states[37] = new State(new int[]{28,39,32,40,31,41,33,42,38,70,39,66,40,67,14,68,15,69},new int[]{-27,38,-28,37});
    states[38] = new State(-72);
    states[39] = new State(-79);
    states[40] = new State(-80);
    states[41] = new State(-81);
    states[42] = new State(new int[]{11,43,12,45,38,23,28,39,32,40,31,41,33,42,39,66,40,67,14,68,15,69},new int[]{-2,47,-22,26,-23,49,-24,56,-25,59,-26,62,-27,65,-28,37});
    states[43] = new State(new int[]{34,44});
    states[44] = new State(-82);
    states[45] = new State(new int[]{34,46});
    states[46] = new State(-83);
    states[47] = new State(new int[]{34,48});
    states[48] = new State(-78);
    states[49] = new State(new int[]{21,50,22,51,23,52,24,53,25,54,26,55,19,-49,20,-49,37,-49,34,-49},new int[]{-16,29});
    states[50] = new State(-54);
    states[51] = new State(-55);
    states[52] = new State(-56);
    states[53] = new State(-57);
    states[54] = new State(-58);
    states[55] = new State(-59);
    states[56] = new State(new int[]{27,57,28,58,21,-53,22,-53,23,-53,24,-53,25,-53,26,-53,19,-53,20,-53,37,-53,34,-53},new int[]{-15,31});
    states[57] = new State(-62);
    states[58] = new State(-63);
    states[59] = new State(new int[]{29,60,30,61,27,-61,28,-61,21,-61,22,-61,23,-61,24,-61,25,-61,26,-61,19,-61,20,-61,37,-61,34,-61},new int[]{-14,33});
    states[60] = new State(-66);
    states[61] = new State(-67);
    states[62] = new State(new int[]{17,63,18,64,29,-65,30,-65,27,-65,28,-65,21,-65,22,-65,23,-65,24,-65,25,-65,26,-65,19,-65,20,-65,37,-65,34,-65},new int[]{-13,35});
    states[63] = new State(-70);
    states[64] = new State(-71);
    states[65] = new State(-69);
    states[66] = new State(-74);
    states[67] = new State(-75);
    states[68] = new State(-76);
    states[69] = new State(-77);
    states[70] = new State(-73);
    states[71] = new State(-50);
    states[72] = new State(-51);
    states[73] = new State(-32);
    states[74] = new State(new int[]{33,75});
    states[75] = new State(new int[]{38,23,28,39,32,40,31,41,33,42,39,66,40,67,14,68,15,69},new int[]{-2,76,-22,26,-23,49,-24,56,-25,59,-26,62,-27,65,-28,37});
    states[76] = new State(new int[]{34,77});
    states[77] = new State(new int[]{35,17,38,23,28,39,32,40,31,41,33,42,39,66,40,67,14,68,15,69,5,74,7,82,8,88,9,92,10,98},new int[]{-3,78,-4,16,-5,20,-2,21,-22,26,-23,49,-24,56,-25,59,-26,62,-27,65,-28,37,-6,73,-7,81,-8,87,-9,91,-10,97});
    states[78] = new State(new int[]{6,79,2,-40,42,-40,35,-40,38,-40,28,-40,32,-40,31,-40,33,-40,39,-40,40,-40,14,-40,15,-40,5,-40,7,-40,8,-40,9,-40,10,-40,36,-40});
    states[79] = new State(new int[]{35,17,38,23,28,39,32,40,31,41,33,42,39,66,40,67,14,68,15,69,5,74,7,82,8,88,9,92,10,98},new int[]{-3,80,-4,16,-5,20,-2,21,-22,26,-23,49,-24,56,-25,59,-26,62,-27,65,-28,37,-6,73,-7,81,-8,87,-9,91,-10,97});
    states[80] = new State(-39);
    states[81] = new State(-33);
    states[82] = new State(new int[]{33,83});
    states[83] = new State(new int[]{38,23,28,39,32,40,31,41,33,42,39,66,40,67,14,68,15,69},new int[]{-2,84,-22,26,-23,49,-24,56,-25,59,-26,62,-27,65,-28,37});
    states[84] = new State(new int[]{34,85});
    states[85] = new State(new int[]{35,17,38,23,28,39,32,40,31,41,33,42,39,66,40,67,14,68,15,69,5,74,7,82,8,88,9,92,10,98},new int[]{-3,86,-4,16,-5,20,-2,21,-22,26,-23,49,-24,56,-25,59,-26,62,-27,65,-28,37,-6,73,-7,81,-8,87,-9,91,-10,97});
    states[86] = new State(-41);
    states[87] = new State(-34);
    states[88] = new State(new int[]{38,89});
    states[89] = new State(new int[]{37,90});
    states[90] = new State(-42);
    states[91] = new State(-35);
    states[92] = new State(new int[]{41,95,38,23,28,39,32,40,31,41,33,42,39,66,40,67,14,68,15,69},new int[]{-2,93,-22,26,-23,49,-24,56,-25,59,-26,62,-27,65,-28,37});
    states[93] = new State(new int[]{37,94});
    states[94] = new State(-43);
    states[95] = new State(new int[]{37,96});
    states[96] = new State(-44);
    states[97] = new State(-36);
    states[98] = new State(new int[]{37,99});
    states[99] = new State(-45);
    states[100] = new State(-16);
    states[101] = new State(new int[]{42,103,11,108,12,109,13,110,35,-22,38,-22,28,-22,32,-22,31,-22,33,-22,39,-22,40,-22,14,-22,15,-22,5,-22,7,-22,8,-22,9,-22,10,-22,36,-22},new int[]{-1,102,-12,104,-21,105});
    states[102] = new State(-18);
    states[103] = new State(-20);
    states[104] = new State(new int[]{35,17,38,23,28,39,32,40,31,41,33,42,39,66,40,67,14,68,15,69,5,74,7,82,8,88,9,92,10,98,36,-15},new int[]{-3,12,-4,16,-5,20,-2,21,-22,26,-23,49,-24,56,-25,59,-26,62,-27,65,-28,37,-6,73,-7,81,-8,87,-9,91,-10,97});
    states[105] = new State(new int[]{38,106});
    states[106] = new State(new int[]{37,107});
    states[107] = new State(-26);
    states[108] = new State(-27);
    states[109] = new State(-28);
    states[110] = new State(-29);
    states[111] = new State(-19);
    states[112] = new State(new int[]{35,113,42,119});
    states[113] = new State(-17,new int[]{-20,114,-11,10});
    states[114] = new State(new int[]{36,115});
    states[115] = new State(new int[]{42,116,2,117});
    states[116] = new State(-4);
    states[117] = new State(new int[]{42,118});
    states[118] = new State(-8);
    states[119] = new State(-11);
    states[120] = new State(-10);
    states[121] = new State(new int[]{4,122,42,136});
    states[122] = new State(new int[]{35,123,2,129});
    states[123] = new State(-17,new int[]{-20,124,-11,10});
    states[124] = new State(new int[]{36,125});
    states[125] = new State(new int[]{42,126,2,127});
    states[126] = new State(-3);
    states[127] = new State(new int[]{42,128});
    states[128] = new State(-7);
    states[129] = new State(new int[]{35,130});
    states[130] = new State(-17,new int[]{-20,131,-11,10});
    states[131] = new State(new int[]{36,132});
    states[132] = new State(new int[]{42,133,2,134});
    states[133] = new State(-6);
    states[134] = new State(new int[]{42,135});
    states[135] = new State(-9);
    states[136] = new State(-13);
    states[137] = new State(-12);

    for (int sNo = 0; sNo < states.Length; sNo++) states[sNo].number = sNo;

    rules[1] = new Rule(-19, new int[]{-18,3});
    rules[2] = new Rule(-18, new int[]{4,35,-20,36,42});
    rules[3] = new Rule(-18, new int[]{2,4,35,-20,36,42});
    rules[4] = new Rule(-18, new int[]{4,2,35,-20,36,42});
    rules[5] = new Rule(-18, new int[]{4,35,-20,36,2,42});
    rules[6] = new Rule(-18, new int[]{2,4,2,35,-20,36,42});
    rules[7] = new Rule(-18, new int[]{2,4,35,-20,36,2,42});
    rules[8] = new Rule(-18, new int[]{4,2,35,-20,36,2,42});
    rules[9] = new Rule(-18, new int[]{2,4,2,35,-20,36,2,42});
    rules[10] = new Rule(-18, new int[]{4,42});
    rules[11] = new Rule(-18, new int[]{4,2,42});
    rules[12] = new Rule(-18, new int[]{42});
    rules[13] = new Rule(-18, new int[]{2,42});
    rules[14] = new Rule(-20, new int[]{-11,-12});
    rules[15] = new Rule(-20, new int[]{-11,2,-12});
    rules[16] = new Rule(-11, new int[]{-11,-1});
    rules[17] = new Rule(-11, new int[]{});
    rules[18] = new Rule(-11, new int[]{-11,2,-1});
    rules[19] = new Rule(-11, new int[]{-11,42});
    rules[20] = new Rule(-11, new int[]{-11,2,42});
    rules[21] = new Rule(-12, new int[]{-12,-3});
    rules[22] = new Rule(-12, new int[]{});
    rules[23] = new Rule(-12, new int[]{-12,-3,2});
    rules[24] = new Rule(-12, new int[]{-12,-3,42});
    rules[25] = new Rule(-12, new int[]{-12,-3,2,42});
    rules[26] = new Rule(-1, new int[]{-21,38,37});
    rules[27] = new Rule(-21, new int[]{11});
    rules[28] = new Rule(-21, new int[]{12});
    rules[29] = new Rule(-21, new int[]{13});
    rules[30] = new Rule(-3, new int[]{-4});
    rules[31] = new Rule(-3, new int[]{-5});
    rules[32] = new Rule(-3, new int[]{-6});
    rules[33] = new Rule(-3, new int[]{-7});
    rules[34] = new Rule(-3, new int[]{-8});
    rules[35] = new Rule(-3, new int[]{-9});
    rules[36] = new Rule(-3, new int[]{-10});
    rules[37] = new Rule(-4, new int[]{35,-12,36});
    rules[38] = new Rule(-5, new int[]{-2,37});
    rules[39] = new Rule(-6, new int[]{5,33,-2,34,-3,6,-3});
    rules[40] = new Rule(-6, new int[]{5,33,-2,34,-3});
    rules[41] = new Rule(-7, new int[]{7,33,-2,34,-3});
    rules[42] = new Rule(-8, new int[]{8,38,37});
    rules[43] = new Rule(-9, new int[]{9,-2,37});
    rules[44] = new Rule(-9, new int[]{9,41,37});
    rules[45] = new Rule(-10, new int[]{10,37});
    rules[46] = new Rule(-2, new int[]{38,16,-2});
    rules[47] = new Rule(-2, new int[]{-22});
    rules[48] = new Rule(-22, new int[]{-22,-17,-23});
    rules[49] = new Rule(-22, new int[]{-23});
    rules[50] = new Rule(-17, new int[]{19});
    rules[51] = new Rule(-17, new int[]{20});
    rules[52] = new Rule(-23, new int[]{-23,-16,-24});
    rules[53] = new Rule(-23, new int[]{-24});
    rules[54] = new Rule(-16, new int[]{21});
    rules[55] = new Rule(-16, new int[]{22});
    rules[56] = new Rule(-16, new int[]{23});
    rules[57] = new Rule(-16, new int[]{24});
    rules[58] = new Rule(-16, new int[]{25});
    rules[59] = new Rule(-16, new int[]{26});
    rules[60] = new Rule(-24, new int[]{-24,-15,-25});
    rules[61] = new Rule(-24, new int[]{-25});
    rules[62] = new Rule(-15, new int[]{27});
    rules[63] = new Rule(-15, new int[]{28});
    rules[64] = new Rule(-25, new int[]{-25,-14,-26});
    rules[65] = new Rule(-25, new int[]{-26});
    rules[66] = new Rule(-14, new int[]{29});
    rules[67] = new Rule(-14, new int[]{30});
    rules[68] = new Rule(-26, new int[]{-26,-13,-27});
    rules[69] = new Rule(-26, new int[]{-27});
    rules[70] = new Rule(-13, new int[]{17});
    rules[71] = new Rule(-13, new int[]{18});
    rules[72] = new Rule(-27, new int[]{-28,-27});
    rules[73] = new Rule(-27, new int[]{38});
    rules[74] = new Rule(-27, new int[]{39});
    rules[75] = new Rule(-27, new int[]{40});
    rules[76] = new Rule(-27, new int[]{14});
    rules[77] = new Rule(-27, new int[]{15});
    rules[78] = new Rule(-27, new int[]{33,-2,34});
    rules[79] = new Rule(-28, new int[]{28});
    rules[80] = new Rule(-28, new int[]{32});
    rules[81] = new Rule(-28, new int[]{31});
    rules[82] = new Rule(-28, new int[]{33,11,34});
    rules[83] = new Rule(-28, new int[]{33,12,34});
  }

  protected override void Initialize() {
    this.InitSpecialTokens((int)Tokens.error, (int)Tokens.EOF);
    this.InitStates(states);
    this.InitRules(rules);
    this.InitNonTerminals(nonTerms);
  }

  protected override void DoAction(int action)
  {
#pragma warning disable 162, 1522
    switch (action)
    {
      case 2: // Lang -> prog, lcurlybracket, Block, rcurlybracket, eof
#line 44 ".\files\kompilator.y"
  {
			YYAccept();

		}
#line default
        break;
      case 3: // Lang -> error, prog, lcurlybracket, Block, rcurlybracket, eof
#line 49 ".\files\kompilator.y"
  {
			SyntaxError("Wrong code before \'program\' block", ValueStack[ValueStack.Depth-6].lineAfter);
			yyerrok();
			YYAccept();

		}
#line default
        break;
      case 4: // Lang -> prog, error, lcurlybracket, Block, rcurlybracket, eof
#line 56 ".\files\kompilator.y"
  {
			SyntaxError("Wrong code after \'program\' keyword", ValueStack[ValueStack.Depth-5].lineAfter);
			yyerrok();
			YYAccept();
		}
#line default
        break;
      case 5: // Lang -> prog, lcurlybracket, Block, rcurlybracket, error, eof
#line 62 ".\files\kompilator.y"
  {
			SyntaxError("Wrong code after \'program\' block", ValueStack[ValueStack.Depth-2].lineAfter);
			yyerrok();
			YYAccept();
		}
#line default
        break;
      case 6: // Lang -> error, prog, error, lcurlybracket, Block, rcurlybracket, eof
#line 68 ".\files\kompilator.y"
  {
			SyntaxError("Wrong code before \'program\' block", ValueStack[ValueStack.Depth-7].lineAfter);
			SyntaxError("Wrong code after \'program\' keyword", ValueStack[ValueStack.Depth-5].lineAfter);
			yyerrok();
			YYAccept();
		}
#line default
        break;
      case 7: // Lang -> error, prog, lcurlybracket, Block, rcurlybracket, error, eof
#line 75 ".\files\kompilator.y"
  {
			SyntaxError("Wrong code before \'program\' block", ValueStack[ValueStack.Depth-7].lineAfter);
			SyntaxError("Wrong code after \'program\' block", ValueStack[ValueStack.Depth-2].lineAfter);
			yyerrok();
			YYAccept();
		}
#line default
        break;
      case 8: // Lang -> prog, error, lcurlybracket, Block, rcurlybracket, error, eof
#line 82 ".\files\kompilator.y"
  {
			SyntaxError("Wrong code after \'program\' keyword", ValueStack[ValueStack.Depth-6].lineAfter);
			SyntaxError("Wrong code after \'program\' block", ValueStack[ValueStack.Depth-2].lineAfter);
			yyerrok();
			YYAccept();
		}
#line default
        break;
      case 9: // Lang -> error, prog, error, lcurlybracket, Block, rcurlybracket, error, eof
#line 89 ".\files\kompilator.y"
  {
			SyntaxError("Wrong code before \'program\' block", ValueStack[ValueStack.Depth-8].lineAfter);
			SyntaxError("Wrong code after \'program\' keyword", ValueStack[ValueStack.Depth-6].lineAfter);
			SyntaxError("Wrong code after \'program\' block", ValueStack[ValueStack.Depth-2].lineAfter);
			yyerrok();
			YYAccept();
		}
#line default
        break;
      case 10: // Lang -> prog, eof
#line 97 ".\files\kompilator.y"
  {
			SyntaxError("Unexpected symbol: EOF", ValueStack[ValueStack.Depth-1].lineAfter);
			yyerrok();
			YYAccept();
		}
#line default
        break;
      case 11: // Lang -> prog, error, eof
#line 103 ".\files\kompilator.y"
  {
			SyntaxError("Wrong code after \'program\' keyword", ValueStack[ValueStack.Depth-2].lineAfter);
			SyntaxError("Unexpected symbol: EOF", ValueStack[ValueStack.Depth-1].lineAfter);
			yyerrok();
			YYAccept();
		}
#line default
        break;
      case 12: // Lang -> eof
#line 110 ".\files\kompilator.y"
  {
			SyntaxError("Unexpected symbol: EOF", ValueStack[ValueStack.Depth-1].lineAfter);
			yyerrok();
			YYAccept();
		}
#line default
        break;
      case 13: // Lang -> error, eof
#line 116 ".\files\kompilator.y"
  {
			SyntaxError("Wrong code before \'program\' block", ValueStack[ValueStack.Depth-2].lineAfter);
			SyntaxError("Unexpected symbol: EOF", ValueStack[ValueStack.Depth-1].lineAfter);
			yyerrok();
			YYAccept();
		}
#line default
        break;
      case 14: // Block -> DeclarationPart, InstructionPart
#line 125 ".\files\kompilator.y"
  {
			List<SyntaxTree> list = ValueStack[ValueStack.Depth-2].list;
			list.AddRange(ValueStack[ValueStack.Depth-1].list);
			Compiler.code = list;
		}
#line default
        break;
      case 15: // Block -> DeclarationPart, error, InstructionPart
#line 131 ".\files\kompilator.y"
  {
			List<SyntaxTree> list = ValueStack[ValueStack.Depth-3].list;
			list.AddRange(ValueStack[ValueStack.Depth-1].list);
			Compiler.code = list;
			SyntaxError("Invalid instruction", ValueStack[ValueStack.Depth-2].lineBefore);
			yyerrok();
		}
#line default
        break;
      case 16: // DeclarationPart -> DeclarationPart, Declaration
#line 141 ".\files\kompilator.y"
  {
			List<SyntaxTree> list = ValueStack[ValueStack.Depth-2].list;
			if (ValueStack[ValueStack.Depth-1].st != null) list.Add(ValueStack[ValueStack.Depth-1].st);
			lastDeclPart = list;
			CurrentSemanticValue.list = list;
		}
#line default
        break;
      case 17: // DeclarationPart -> /* empty */
#line 148 ".\files\kompilator.y"
  {
			List<SyntaxTree> list = new List<SyntaxTree>();
			lastDeclPart = list;
			CurrentSemanticValue.list = list;
		}
#line default
        break;
      case 18: // DeclarationPart -> DeclarationPart, error, Declaration
#line 154 ".\files\kompilator.y"
  {
			List<SyntaxTree> list = ValueStack[ValueStack.Depth-3].list;
			if (ValueStack[ValueStack.Depth-1].st != null) list.Add(ValueStack[ValueStack.Depth-1].st);
			lastDeclPart = list;
			CurrentSemanticValue.list = list;
			SyntaxError("Invalid declaration", ValueStack[ValueStack.Depth-2].lineBefore);
			yyerrok();
		}
#line default
        break;
      case 19: // DeclarationPart -> DeclarationPart, eof
#line 163 ".\files\kompilator.y"
  {
			List<SyntaxTree> list = ValueStack[ValueStack.Depth-2].list;
			lastDeclPart = list;
			CurrentSemanticValue.list = list;
			Compiler.code = list;
			SyntaxError("Unexpected symbol: EOF", ValueStack[ValueStack.Depth-1].lineAfter);
			yyerrok();
			YYAccept();
		}
#line default
        break;
      case 20: // DeclarationPart -> DeclarationPart, error, eof
#line 173 ".\files\kompilator.y"
  {
			List<SyntaxTree> list = ValueStack[ValueStack.Depth-3].list;
			lastDeclPart = list;
			CurrentSemanticValue.list = list;
			Compiler.code = list;
			SyntaxError("Invalid declaration", ValueStack[ValueStack.Depth-2].lineAfter);
			SyntaxError("Unexpected symbol: EOF", ValueStack[ValueStack.Depth-1].lineAfter);
			yyerrok();
			YYAccept();
		}
#line default
        break;
      case 21: // InstructionPart -> InstructionPart, Instruction
#line 186 ".\files\kompilator.y"
  {
			List<SyntaxTree> list = ValueStack[ValueStack.Depth-2].list;
			if (ValueStack[ValueStack.Depth-1].st != null) list.Add(ValueStack[ValueStack.Depth-1].st);
			lastInstPart = list;
			CurrentSemanticValue.list = list;
		}
#line default
        break;
      case 22: // InstructionPart -> /* empty */
#line 193 ".\files\kompilator.y"
  {
			List<SyntaxTree> list = new List<SyntaxTree>();
			lastInstPart = list;
			CurrentSemanticValue.list = list;
		}
#line default
        break;
      case 23: // InstructionPart -> InstructionPart, Instruction, error
#line 199 ".\files\kompilator.y"
  {
			List<SyntaxTree> list = ValueStack[ValueStack.Depth-3].list;
			if (ValueStack[ValueStack.Depth-2].st != null) list.Add(ValueStack[ValueStack.Depth-2].st);
			lastInstPart = list;
			CurrentSemanticValue.list = list;
			SyntaxError("Invalid instruction", ValueStack[ValueStack.Depth-1].lineAfter);
			yyerrok();
		}
#line default
        break;
      case 24: // InstructionPart -> InstructionPart, Instruction, eof
#line 208 ".\files\kompilator.y"
  {
			List<SyntaxTree> list = ValueStack[ValueStack.Depth-3].list;
			if (ValueStack[ValueStack.Depth-2].st != null) list.Add(ValueStack[ValueStack.Depth-2].st);
			lastInstPart = list;
			CurrentSemanticValue.list = list;
			List<SyntaxTree> listEnd = lastDeclPart;
			listEnd.AddRange(list);
			Compiler.code = listEnd;
			SyntaxError("Unexpected symbol: EOF", ValueStack[ValueStack.Depth-1].lineAfter);
			yyerrok();
			YYAccept();
		}
#line default
        break;
      case 25: // InstructionPart -> InstructionPart, Instruction, error, eof
#line 221 ".\files\kompilator.y"
  {
			List<SyntaxTree> list = ValueStack[ValueStack.Depth-4].list;
			if (ValueStack[ValueStack.Depth-3].st != null) list.Add(ValueStack[ValueStack.Depth-3].st);
			lastInstPart = list;
			CurrentSemanticValue.list = list;
			List<SyntaxTree> listEnd = lastDeclPart;
			listEnd.AddRange(list);
			Compiler.code = listEnd;
			SyntaxError("Invalid instruction", ValueStack[ValueStack.Depth-2].lineAfter);
			SyntaxError("Unexpected symbol: EOF", ValueStack[ValueStack.Depth-1].lineAfter);
			yyerrok();
			YYAccept();
		}
#line default
        break;
      case 26: // Declaration -> Type, id, semicolon
#line 239 ".\files\kompilator.y"
  {
			Ident stId = new Ident(ValueStack[ValueStack.Depth-2].val, ValueStack[ValueStack.Depth-2].lineAfter);
			Declaration st = new Declaration((TypeVal)ValueStack[ValueStack.Depth-3].st, stId, ValueStack[ValueStack.Depth-3].lineAfter);
			CurrentSemanticValue.st = st;
		}
#line default
        break;
      case 27: // Type -> inttype
#line 247 ".\files\kompilator.y"
  {
			TypeVal st = new TypeVal('i', ValueStack[ValueStack.Depth-1].lineAfter);
			CurrentSemanticValue.st = st;
		}
#line default
        break;
      case 28: // Type -> doubletype
#line 252 ".\files\kompilator.y"
  {
			TypeVal st = new TypeVal('d', ValueStack[ValueStack.Depth-1].lineAfter);
			CurrentSemanticValue.st = st;
		}
#line default
        break;
      case 29: // Type -> booltype
#line 257 ".\files\kompilator.y"
  {
			TypeVal st = new TypeVal('b', ValueStack[ValueStack.Depth-1].lineAfter);
			CurrentSemanticValue.st = st;
		}
#line default
        break;
      case 30: // Instruction -> BlockInst
#line 266 ".\files\kompilator.y"
  {
			CurrentSemanticValue.st = ValueStack[ValueStack.Depth-1].st;
		}
#line default
        break;
      case 31: // Instruction -> ExpInst
#line 270 ".\files\kompilator.y"
  {
			CurrentSemanticValue.st = ValueStack[ValueStack.Depth-1].st;
		}
#line default
        break;
      case 32: // Instruction -> CondInst
#line 274 ".\files\kompilator.y"
  {
			CurrentSemanticValue.st = ValueStack[ValueStack.Depth-1].st;
		}
#line default
        break;
      case 33: // Instruction -> LoopInst
#line 278 ".\files\kompilator.y"
  {
			CurrentSemanticValue.st = ValueStack[ValueStack.Depth-1].st;
		}
#line default
        break;
      case 34: // Instruction -> InInst
#line 282 ".\files\kompilator.y"
  {
			CurrentSemanticValue.st = ValueStack[ValueStack.Depth-1].st;
		}
#line default
        break;
      case 35: // Instruction -> OutInst
#line 286 ".\files\kompilator.y"
  {
			CurrentSemanticValue.st = ValueStack[ValueStack.Depth-1].st;
		}
#line default
        break;
      case 36: // Instruction -> RetInst
#line 290 ".\files\kompilator.y"
  {
			CurrentSemanticValue.st = ValueStack[ValueStack.Depth-1].st;
		}
#line default
        break;
      case 37: // BlockInst -> lcurlybracket, InstructionPart, rcurlybracket
#line 296 ".\files\kompilator.y"
  {
			BlockInst st = new BlockInst(ValueStack[ValueStack.Depth-2].list, ValueStack[ValueStack.Depth-3].lineAfter);
			CurrentSemanticValue.st = st;
		}
#line default
        break;
      case 38: // ExpInst -> Exp7, semicolon
#line 303 ".\files\kompilator.y"
  {
			SyntaxTree st = ValueStack[ValueStack.Depth-2].st;
			CurrentSemanticValue.st = st;
		}
#line default
        break;
      case 39: // CondInst -> ifstmt, lbracket, Exp7, rbracket, Instruction, elsestmt, 
               //             Instruction
#line 310 ".\files\kompilator.y"
  {
			CondInst st = new CondInst(ValueStack[ValueStack.Depth-5].st, ValueStack[ValueStack.Depth-3].st, ValueStack[ValueStack.Depth-1].st, ValueStack[ValueStack.Depth-7].lineAfter);
			CurrentSemanticValue.st = st;
		}
#line default
        break;
      case 40: // CondInst -> ifstmt, lbracket, Exp7, rbracket, Instruction
#line 315 ".\files\kompilator.y"
  {
			CondInst st = new CondInst(ValueStack[ValueStack.Depth-3].st, ValueStack[ValueStack.Depth-1].st, null, ValueStack[ValueStack.Depth-5].lineAfter);
			CurrentSemanticValue.st = st;
		}
#line default
        break;
      case 41: // LoopInst -> whilestmt, lbracket, Exp7, rbracket, Instruction
#line 322 ".\files\kompilator.y"
  {
			LoopInst st = new LoopInst(ValueStack[ValueStack.Depth-3].st, ValueStack[ValueStack.Depth-1].st, ValueStack[ValueStack.Depth-5].lineAfter);
			CurrentSemanticValue.st = st;
		}
#line default
        break;
      case 42: // InInst -> read, id, semicolon
#line 329 ".\files\kompilator.y"
  {
			Ident stId = new Ident(ValueStack[ValueStack.Depth-2].val, ValueStack[ValueStack.Depth-2].lineAfter);
			InInst st = new InInst(stId, ValueStack[ValueStack.Depth-3].lineAfter);
			CurrentSemanticValue.st = st;
		}
#line default
        break;
      case 43: // OutInst -> write, Exp7, semicolon
#line 337 ".\files\kompilator.y"
  {
			OutInst st = new OutInst(ValueStack[ValueStack.Depth-2].st, null, ValueStack[ValueStack.Depth-3].lineAfter);
			CurrentSemanticValue.st = st;
		}
#line default
        break;
      case 44: // OutInst -> write, str, semicolon
#line 342 ".\files\kompilator.y"
  {
			StringVal stStr = new StringVal(ValueStack[ValueStack.Depth-2].val, ValueStack[ValueStack.Depth-2].lineAfter);
			OutInst st = new OutInst(null, stStr, ValueStack[ValueStack.Depth-3].lineAfter);
			CurrentSemanticValue.st = st;
		}
#line default
        break;
      case 45: // RetInst -> ret, semicolon
#line 350 ".\files\kompilator.y"
  {
			RetInst st = new RetInst(ValueStack[ValueStack.Depth-2].lineAfter);
			CurrentSemanticValue.st = st;
		}
#line default
        break;
      case 46: // Exp7 -> id, assign, Exp7
#line 359 ".\files\kompilator.y"
  {
			Ident stId = new Ident(ValueStack[ValueStack.Depth-3].val, ValueStack[ValueStack.Depth-3].lineAfter);
			ExpInst st = new ExpInst(stId, Tokens.assign, ValueStack[ValueStack.Depth-1].st, ValueStack[ValueStack.Depth-3].lineAfter);
			CurrentSemanticValue.st = st;
		}
#line default
        break;
      case 47: // Exp7 -> Exp6
#line 365 ".\files\kompilator.y"
  {
			SyntaxTree st = ValueStack[ValueStack.Depth-1].st;
			CurrentSemanticValue.st = st;
		}
#line default
        break;
      case 48: // Exp6 -> Exp6, Op6, Exp5
#line 372 ".\files\kompilator.y"
  {
			ExpInst st = new ExpInst(ValueStack[ValueStack.Depth-3].st, ValueStack[ValueStack.Depth-2].tok, ValueStack[ValueStack.Depth-1].st, ValueStack[ValueStack.Depth-3].lineAfter);
			CurrentSemanticValue.st = st;
		}
#line default
        break;
      case 49: // Exp6 -> Exp5
#line 377 ".\files\kompilator.y"
  {
			SyntaxTree st = ValueStack[ValueStack.Depth-1].st;
			CurrentSemanticValue.st = st;
		}
#line default
        break;
      case 50: // Op6 -> lor
#line 384 ".\files\kompilator.y"
  {
			Tokens tok = Tokens.lor;
			CurrentSemanticValue.tok = tok;
		}
#line default
        break;
      case 51: // Op6 -> land
#line 389 ".\files\kompilator.y"
  {
			Tokens tok = Tokens.land;
			CurrentSemanticValue.tok = tok;
		}
#line default
        break;
      case 52: // Exp5 -> Exp5, Op5, Exp4
#line 396 ".\files\kompilator.y"
  {
			ExpInst st = new ExpInst(ValueStack[ValueStack.Depth-3].st, ValueStack[ValueStack.Depth-2].tok, ValueStack[ValueStack.Depth-1].st, ValueStack[ValueStack.Depth-3].lineAfter);
			CurrentSemanticValue.st = st;
		}
#line default
        break;
      case 53: // Exp5 -> Exp4
#line 401 ".\files\kompilator.y"
  {
			SyntaxTree st = ValueStack[ValueStack.Depth-1].st;
			CurrentSemanticValue.st = st;
		}
#line default
        break;
      case 54: // Op5 -> equal
#line 408 ".\files\kompilator.y"
  {
			Tokens tok = Tokens.equal;
			CurrentSemanticValue.tok = tok;
		}
#line default
        break;
      case 55: // Op5 -> diff
#line 413 ".\files\kompilator.y"
  {
			Tokens tok = Tokens.diff;
			CurrentSemanticValue.tok = tok;
		}
#line default
        break;
      case 56: // Op5 -> larger
#line 418 ".\files\kompilator.y"
  {
			Tokens tok = Tokens.larger;
			CurrentSemanticValue.tok = tok;
		}
#line default
        break;
      case 57: // Op5 -> largere
#line 423 ".\files\kompilator.y"
  {
			Tokens tok = Tokens.largere;
			CurrentSemanticValue.tok = tok;
		}
#line default
        break;
      case 58: // Op5 -> smaller
#line 428 ".\files\kompilator.y"
  {
			Tokens tok = Tokens.smaller;
			CurrentSemanticValue.tok = tok;
		}
#line default
        break;
      case 59: // Op5 -> smallere
#line 433 ".\files\kompilator.y"
  {
			Tokens tok = Tokens.smallere;
			CurrentSemanticValue.tok = tok;
		}
#line default
        break;
      case 60: // Exp4 -> Exp4, Op4, Exp3
#line 440 ".\files\kompilator.y"
  {
			ExpInst st = new ExpInst(ValueStack[ValueStack.Depth-3].st, ValueStack[ValueStack.Depth-2].tok, ValueStack[ValueStack.Depth-1].st, ValueStack[ValueStack.Depth-3].lineAfter);
			CurrentSemanticValue.st = st;
		}
#line default
        break;
      case 61: // Exp4 -> Exp3
#line 445 ".\files\kompilator.y"
  {
			SyntaxTree st = ValueStack[ValueStack.Depth-1].st;
			CurrentSemanticValue.st = st;
		}
#line default
        break;
      case 62: // Op4 -> plus
#line 452 ".\files\kompilator.y"
  {
			Tokens tok = Tokens.plus;
			CurrentSemanticValue.tok = tok;
		}
#line default
        break;
      case 63: // Op4 -> minus
#line 457 ".\files\kompilator.y"
  {
			Tokens tok = Tokens.minus;
			CurrentSemanticValue.tok = tok;
		}
#line default
        break;
      case 64: // Exp3 -> Exp3, Op3, Exp2
#line 464 ".\files\kompilator.y"
  {
			ExpInst st = new ExpInst(ValueStack[ValueStack.Depth-3].st, ValueStack[ValueStack.Depth-2].tok, ValueStack[ValueStack.Depth-1].st, ValueStack[ValueStack.Depth-3].lineAfter);
			CurrentSemanticValue.st = st;
		}
#line default
        break;
      case 65: // Exp3 -> Exp2
#line 469 ".\files\kompilator.y"
  {
			SyntaxTree st = ValueStack[ValueStack.Depth-1].st;
			CurrentSemanticValue.st = st;
		}
#line default
        break;
      case 66: // Op3 -> mul
#line 476 ".\files\kompilator.y"
  {
			Tokens tok = Tokens.mul;
			CurrentSemanticValue.tok = tok;
		}
#line default
        break;
      case 67: // Op3 -> div
#line 481 ".\files\kompilator.y"
  {
			Tokens tok = Tokens.div;
			CurrentSemanticValue.tok = tok;
		}
#line default
        break;
      case 68: // Exp2 -> Exp2, Op2, Exp1
#line 488 ".\files\kompilator.y"
  {
			ExpInst st = new ExpInst(ValueStack[ValueStack.Depth-3].st, ValueStack[ValueStack.Depth-2].tok, ValueStack[ValueStack.Depth-1].st, ValueStack[ValueStack.Depth-3].lineAfter);
			CurrentSemanticValue.st = st;
		}
#line default
        break;
      case 69: // Exp2 -> Exp1
#line 493 ".\files\kompilator.y"
  {
			SyntaxTree st = ValueStack[ValueStack.Depth-1].st;
		}
#line default
        break;
      case 70: // Op2 -> bor
#line 499 ".\files\kompilator.y"
  {
			Tokens tok = Tokens.bor;
			CurrentSemanticValue.tok = tok;
		}
#line default
        break;
      case 71: // Op2 -> band
#line 504 ".\files\kompilator.y"
  {
			Tokens tok = Tokens.band;
			CurrentSemanticValue.tok = tok;
		}
#line default
        break;
      case 72: // Exp1 -> Op1, Exp1
#line 511 ".\files\kompilator.y"
  {
			ExpInst st = new ExpInst(null, ValueStack[ValueStack.Depth-2].tok, ValueStack[ValueStack.Depth-1].st, ValueStack[ValueStack.Depth-2].lineAfter);
			CurrentSemanticValue.st = st;
		}
#line default
        break;
      case 73: // Exp1 -> id
#line 516 ".\files\kompilator.y"
  {
			Ident st = new Ident(ValueStack[ValueStack.Depth-1].val, ValueStack[ValueStack.Depth-1].lineAfter);
			CurrentSemanticValue.st = st;
		}
#line default
        break;
      case 74: // Exp1 -> numint
#line 521 ".\files\kompilator.y"
  {
			IntVal st = new IntVal(int.Parse(ValueStack[ValueStack.Depth-1].val), ValueStack[ValueStack.Depth-1].lineAfter);
			CurrentSemanticValue.st = st;
		}
#line default
        break;
      case 75: // Exp1 -> numdouble
#line 526 ".\files\kompilator.y"
  {
			DoubleVal st = new DoubleVal(double.Parse(ValueStack[ValueStack.Depth-1].val, CultureInfo.InvariantCulture), ValueStack[ValueStack.Depth-1].lineAfter);
			CurrentSemanticValue.st = st;
		}
#line default
        break;
      case 76: // Exp1 -> t
#line 531 ".\files\kompilator.y"
  {
			BoolVal st = new BoolVal(true, ValueStack[ValueStack.Depth-1].lineAfter);
			CurrentSemanticValue.st = st;
		}
#line default
        break;
      case 77: // Exp1 -> f
#line 536 ".\files\kompilator.y"
  {
			BoolVal st = new BoolVal(false, ValueStack[ValueStack.Depth-1].lineAfter);
			CurrentSemanticValue.st = st;
		}
#line default
        break;
      case 78: // Exp1 -> lbracket, Exp7, rbracket
#line 541 ".\files\kompilator.y"
  {
			SyntaxTree st = ValueStack[ValueStack.Depth-2].st;
			CurrentSemanticValue.st = st;
		}
#line default
        break;
      case 79: // Op1 -> minus
#line 548 ".\files\kompilator.y"
  {
			Tokens tok = Tokens.minus;
			CurrentSemanticValue.tok = tok;
		}
#line default
        break;
      case 80: // Op1 -> bneg
#line 553 ".\files\kompilator.y"
  {
			Tokens tok = Tokens.bneg;
			CurrentSemanticValue.tok = tok;
		}
#line default
        break;
      case 81: // Op1 -> lneg
#line 558 ".\files\kompilator.y"
  {
			Tokens tok = Tokens.lneg;
			CurrentSemanticValue.tok = tok;
		}
#line default
        break;
      case 82: // Op1 -> lbracket, inttype, rbracket
#line 563 ".\files\kompilator.y"
  {
			Tokens tok = Tokens.inttype;
			CurrentSemanticValue.tok = tok;
		}
#line default
        break;
      case 83: // Op1 -> lbracket, doubletype, rbracket
#line 568 ".\files\kompilator.y"
  {
			Tokens tok = Tokens.doubletype;
			CurrentSemanticValue.tok = tok;
		}
#line default
        break;
    }
#pragma warning restore 162, 1522
  }

  protected override string TerminalToString(int terminal)
  {
    if (aliases != null && aliases.ContainsKey(terminal))
        return aliases[terminal];
    else if (((Tokens)terminal).ToString() != terminal.ToString(CultureInfo.InvariantCulture))
        return ((Tokens)terminal).ToString();
    else
        return CharToString((char)terminal);
  }

#line 575 ".\files\kompilator.y"

public static List<SyntaxTree> lastInstPart  = new List<SyntaxTree>();
public static List<SyntaxTree> lastDeclPart  = new List<SyntaxTree>();

public Parser(Scanner scnr) : base(scnr) { }

private void SyntaxError(string msg, int line)
{
	Compiler.errors++;
	if (msg != "") msg += " ";
	Compiler.SaveError(msg, ErrorType.Syntax, line, msg=="" ? true : false);
}
#line default
}
}
