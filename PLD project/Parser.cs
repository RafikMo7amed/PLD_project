
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF           =  0, // (EOF)
        SYMBOL_ERROR         =  1, // (Error)
        SYMBOL_WHITESPACE    =  2, // Whitespace
        SYMBOL_MINUS         =  3, // '-'
        SYMBOL_EXCLAMEQ      =  4, // '!='
        SYMBOL_PERCENT       =  5, // '%'
        SYMBOL_LPAREN        =  6, // '('
        SYMBOL_RPAREN        =  7, // ')'
        SYMBOL_TIMES         =  8, // '*'
        SYMBOL_COMMA         =  9, // ','
        SYMBOL_DIV           = 10, // '/'
        SYMBOL_COLON         = 11, // ':'
        SYMBOL_PLUS          = 12, // '+'
        SYMBOL_LT            = 13, // '<'
        SYMBOL_EQ            = 14, // '='
        SYMBOL_EQEQ          = 15, // '=='
        SYMBOL_GT            = 16, // '>'
        SYMBOL_CASE          = 17, // case
        SYMBOL_DEF           = 18, // def
        SYMBOL_DEFAULTCOLON  = 19, // 'default:'
        SYMBOL_DIGIT         = 20, // Digit
        SYMBOL_DO            = 21, // do
        SYMBOL_ELSECOLON     = 22, // 'else:'
        SYMBOL_END           = 23, // end
        SYMBOL_FOR           = 24, // for
        SYMBOL_ID            = 25, // Id
        SYMBOL_IF            = 26, // if
        SYMBOL_IN            = 27, // in
        SYMBOL_PRINT         = 28, // print
        SYMBOL_RANGE         = 29, // range
        SYMBOL_START         = 30, // start
        SYMBOL_SWITCH        = 31, // switch
        SYMBOL_WHILE         = 32, // while
        SYMBOL_ARG_LIST      = 33, // <arg_list>
        SYMBOL_ASSIGN        = 34, // <assign>
        SYMBOL_CASE_BLOCK    = 35, // <case_block>
        SYMBOL_CASE_STMT     = 36, // <case_stmt>
        SYMBOL_CONCEPT       = 37, // <concept>
        SYMBOL_COND          = 38, // <cond>
        SYMBOL_DIGIT2        = 39, // <digit>
        SYMBOL_DO_WHILE_STMT = 40, // <do_while_stmt>
        SYMBOL_EXPR          = 41, // <expr>
        SYMBOL_FACTOR        = 42, // <factor>
        SYMBOL_FOR_STMT      = 43, // <for_stmt>
        SYMBOL_FUNC_CALL     = 44, // <func_call>
        SYMBOL_FUNC_DEF      = 45, // <func_def>
        SYMBOL_ID2           = 46, // <id>
        SYMBOL_IF_STMT       = 47, // <if_stmt>
        SYMBOL_OP            = 48, // <op>
        SYMBOL_PARAM         = 49, // <param>
        SYMBOL_PARAM_LIST    = 50, // <param_list>
        SYMBOL_PRINT_STMT    = 51, // <print_stmt>
        SYMBOL_PROGRAM       = 52, // <program>
        SYMBOL_STMT          = 53, // <stmt>
        SYMBOL_STMT_BLOCK    = 54, // <stmt_block>
        SYMBOL_STMT_LIST     = 55, // <stmt_list>
        SYMBOL_SWITCH_STMT   = 56, // <switch_stmt>
        SYMBOL_TERM          = 57, // <term>
        SYMBOL_WHILE_STMT    = 58  // <while_stmt>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM_START_END                          =  0, // <program> ::= start <stmt_list> end
        RULE_STMT_LIST                                  =  1, // <stmt_list> ::= <stmt>
        RULE_STMT_LIST2                                 =  2, // <stmt_list> ::= <stmt> <stmt_list>
        RULE_STMT                                       =  3, // <stmt> ::= <concept>
        RULE_STMT2                                      =  4, // <stmt> ::= <print_stmt>
        RULE_CONCEPT                                    =  5, // <concept> ::= <assign>
        RULE_CONCEPT2                                   =  6, // <concept> ::= <if_stmt>
        RULE_CONCEPT3                                   =  7, // <concept> ::= <switch_stmt>
        RULE_CONCEPT4                                   =  8, // <concept> ::= <for_stmt>
        RULE_CONCEPT5                                   =  9, // <concept> ::= <while_stmt>
        RULE_CONCEPT6                                   = 10, // <concept> ::= <do_while_stmt>
        RULE_CONCEPT7                                   = 11, // <concept> ::= <func_def>
        RULE_CONCEPT8                                   = 12, // <concept> ::= <func_call>
        RULE_ASSIGN_EQ                                  = 13, // <assign> ::= <id> '=' <expr>
        RULE_ID_ID                                      = 14, // <id> ::= Id
        RULE_EXPR_PLUS                                  = 15, // <expr> ::= <expr> '+' <term>
        RULE_EXPR_MINUS                                 = 16, // <expr> ::= <expr> '-' <term>
        RULE_EXPR                                       = 17, // <expr> ::= <term>
        RULE_TERM_TIMES                                 = 18, // <term> ::= <term> '*' <factor>
        RULE_TERM_DIV                                   = 19, // <term> ::= <term> '/' <factor>
        RULE_TERM_PERCENT                               = 20, // <term> ::= <term> '%' <factor>
        RULE_TERM                                       = 21, // <term> ::= <factor>
        RULE_FACTOR_LPAREN_RPAREN                       = 22, // <factor> ::= '(' <expr> ')'
        RULE_FACTOR                                     = 23, // <factor> ::= <id>
        RULE_FACTOR2                                    = 24, // <factor> ::= <digit>
        RULE_DIGIT_DIGIT                                = 25, // <digit> ::= Digit
        RULE_IF_STMT_IF_LPAREN_RPAREN_COLON             = 26, // <if_stmt> ::= if '(' <cond> ')' ':' <stmt_block>
        RULE_IF_STMT_IF_LPAREN_RPAREN_COLON_ELSECOLON   = 27, // <if_stmt> ::= if '(' <cond> ')' ':' <stmt_block> 'else:' <stmt_block>
        RULE_COND                                       = 28, // <cond> ::= <expr> <op> <expr>
        RULE_OP_LT                                      = 29, // <op> ::= '<'
        RULE_OP_GT                                      = 30, // <op> ::= '>'
        RULE_OP_EQEQ                                    = 31, // <op> ::= '=='
        RULE_OP_EXCLAMEQ                                = 32, // <op> ::= '!='
        RULE_STMT_BLOCK                                 = 33, // <stmt_block> ::= <stmt>
        RULE_STMT_BLOCK2                                = 34, // <stmt_block> ::= <stmt> <stmt_block>
        RULE_SWITCH_STMT_SWITCH_LPAREN_RPAREN_COLON     = 35, // <switch_stmt> ::= switch '(' <expr> ')' ':' <case_block>
        RULE_CASE_BLOCK                                 = 36, // <case_block> ::= <case_stmt>
        RULE_CASE_BLOCK2                                = 37, // <case_block> ::= <case_stmt> <case_block>
        RULE_CASE_BLOCK_DEFAULTCOLON                    = 38, // <case_block> ::= 'default:' <stmt_block>
        RULE_CASE_STMT_CASE_COLON                       = 39, // <case_stmt> ::= case <expr> ':' <stmt_block>
        RULE_FOR_STMT_FOR_IN_RANGE_LPAREN_RPAREN_COLON  = 40, // <for_stmt> ::= for <id> in range '(' <expr> ')' ':' <stmt_block>
        RULE_WHILE_STMT_WHILE_LPAREN_RPAREN_COLON       = 41, // <while_stmt> ::= while '(' <cond> ')' ':' <stmt_block>
        RULE_DO_WHILE_STMT_DO_COLON_WHILE_LPAREN_RPAREN = 42, // <do_while_stmt> ::= do ':' <stmt_block> while '(' <cond> ')'
        RULE_FUNC_DEF_DEF_LPAREN_RPAREN_COLON           = 43, // <func_def> ::= def <id> '(' <param_list> ')' ':' <stmt_block>
        RULE_PARAM_LIST                                 = 44, // <param_list> ::= <param>
        RULE_PARAM_LIST_COMMA                           = 45, // <param_list> ::= <param> ',' <param_list>
        RULE_PARAM                                      = 46, // <param> ::= <id>
        RULE_FUNC_CALL_LPAREN_RPAREN                    = 47, // <func_call> ::= <id> '(' ')'
        RULE_FUNC_CALL_LPAREN_RPAREN2                   = 48, // <func_call> ::= <id> '(' <arg_list> ')'
        RULE_ARG_LIST                                   = 49, // <arg_list> ::= <expr>
        RULE_ARG_LIST_COMMA                             = 50, // <arg_list> ::= <expr> ',' <arg_list>
        RULE_PRINT_STMT_PRINT_LPAREN_RPAREN             = 51  // <print_stmt> ::= print '(' <expr> ')'
    };

    public class MyParser
    {
        private LALRParser parser;

        public MyParser(string filename)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PERCENT :
                //'%'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLON :
                //':'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASE :
                //case
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DEF :
                //def
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DEFAULTCOLON :
                //'default:'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT :
                //Digit
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DO :
                //do
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSECOLON :
                //'else:'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_END :
                //end
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //for
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID :
                //Id
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IN :
                //in
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PRINT :
                //print
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RANGE :
                //range
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_START :
                //start
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCH :
                //switch
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE :
                //while
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARG_LIST :
                //<arg_list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGN :
                //<assign>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASE_BLOCK :
                //<case_block>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASE_STMT :
                //<case_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONCEPT :
                //<concept>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COND :
                //<cond>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT2 :
                //<digit>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DO_WHILE_STMT :
                //<do_while_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPR :
                //<expr>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FACTOR :
                //<factor>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR_STMT :
                //<for_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNC_CALL :
                //<func_call>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNC_DEF :
                //<func_def>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID2 :
                //<id>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF_STMT :
                //<if_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OP :
                //<op>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARAM :
                //<param>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARAM_LIST :
                //<param_list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PRINT_STMT :
                //<print_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STMT :
                //<stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STMT_BLOCK :
                //<stmt_block>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STMT_LIST :
                //<stmt_list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCH_STMT :
                //<switch_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERM :
                //<term>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE_STMT :
                //<while_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM_START_END :
                //<program> ::= start <stmt_list> end
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT_LIST :
                //<stmt_list> ::= <stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT_LIST2 :
                //<stmt_list> ::= <stmt> <stmt_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT :
                //<stmt> ::= <concept>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT2 :
                //<stmt> ::= <print_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT :
                //<concept> ::= <assign>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT2 :
                //<concept> ::= <if_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT3 :
                //<concept> ::= <switch_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT4 :
                //<concept> ::= <for_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT5 :
                //<concept> ::= <while_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT6 :
                //<concept> ::= <do_while_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT7 :
                //<concept> ::= <func_def>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT8 :
                //<concept> ::= <func_call>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGN_EQ :
                //<assign> ::= <id> '=' <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ID_ID :
                //<id> ::= Id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_PLUS :
                //<expr> ::= <expr> '+' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_MINUS :
                //<expr> ::= <expr> '-' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR :
                //<expr> ::= <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_TIMES :
                //<term> ::= <term> '*' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_DIV :
                //<term> ::= <term> '/' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_PERCENT :
                //<term> ::= <term> '%' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM :
                //<term> ::= <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_LPAREN_RPAREN :
                //<factor> ::= '(' <expr> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR :
                //<factor> ::= <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR2 :
                //<factor> ::= <digit>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DIGIT_DIGIT :
                //<digit> ::= Digit
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STMT_IF_LPAREN_RPAREN_COLON :
                //<if_stmt> ::= if '(' <cond> ')' ':' <stmt_block>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STMT_IF_LPAREN_RPAREN_COLON_ELSECOLON :
                //<if_stmt> ::= if '(' <cond> ')' ':' <stmt_block> 'else:' <stmt_block>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COND :
                //<cond> ::= <expr> <op> <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_LT :
                //<op> ::= '<'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_GT :
                //<op> ::= '>'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EQEQ :
                //<op> ::= '=='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EXCLAMEQ :
                //<op> ::= '!='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT_BLOCK :
                //<stmt_block> ::= <stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT_BLOCK2 :
                //<stmt_block> ::= <stmt> <stmt_block>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SWITCH_STMT_SWITCH_LPAREN_RPAREN_COLON :
                //<switch_stmt> ::= switch '(' <expr> ')' ':' <case_block>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASE_BLOCK :
                //<case_block> ::= <case_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASE_BLOCK2 :
                //<case_block> ::= <case_stmt> <case_block>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASE_BLOCK_DEFAULTCOLON :
                //<case_block> ::= 'default:' <stmt_block>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASE_STMT_CASE_COLON :
                //<case_stmt> ::= case <expr> ':' <stmt_block>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FOR_STMT_FOR_IN_RANGE_LPAREN_RPAREN_COLON :
                //<for_stmt> ::= for <id> in range '(' <expr> ')' ':' <stmt_block>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WHILE_STMT_WHILE_LPAREN_RPAREN_COLON :
                //<while_stmt> ::= while '(' <cond> ')' ':' <stmt_block>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DO_WHILE_STMT_DO_COLON_WHILE_LPAREN_RPAREN :
                //<do_while_stmt> ::= do ':' <stmt_block> while '(' <cond> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNC_DEF_DEF_LPAREN_RPAREN_COLON :
                //<func_def> ::= def <id> '(' <param_list> ')' ':' <stmt_block>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAM_LIST :
                //<param_list> ::= <param>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAM_LIST_COMMA :
                //<param_list> ::= <param> ',' <param_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAM :
                //<param> ::= <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNC_CALL_LPAREN_RPAREN :
                //<func_call> ::= <id> '(' ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNC_CALL_LPAREN_RPAREN2 :
                //<func_call> ::= <id> '(' <arg_list> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARG_LIST :
                //<arg_list> ::= <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARG_LIST_COMMA :
                //<arg_list> ::= <expr> ',' <arg_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRINT_STMT_PRINT_LPAREN_RPAREN :
                //<print_stmt> ::= print '(' <expr> ')'
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+"'";
            //todo: Report message to UI?
        }

    }
}
