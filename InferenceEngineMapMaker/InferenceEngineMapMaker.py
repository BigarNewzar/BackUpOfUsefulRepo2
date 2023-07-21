import GenericStuff
import random
import sys
import CmdHelpLine
import KBTestStuff

def choose_edge_case(number, file_count,n,m,o,multi):
        """
        
        number = int(input("Please choose the number for the test type you want: "))
        file_count = int(input("Please say the number of test files you want to make: "))
        
        n determines how many prepositions will be made
        m determines how many "a => b;" statements will be made
        o determines how many "a&b => c;" statements will be made
        multi determines how many clauses can exist for a&b => c case...
        like a&b&c&d&e&f&g&... => c
           
        
        n = int(input("Please choose the number of symbols you want to use (min 3): "))
        m = int(input("If applicable, please choose the number of single horned clause you want to use:  "))
        o = int(input("If applicable, please choose the number for conjuction horned clause type you want: "))
        multi = int(input("If applicable, please choose the number for multiconjuction horned clause type you want: "))
        """
           
        if number == 1:        
            GenericStuff.normal(file_count,n,m,o)        
        if number == 2:
            GenericStuff.no_tell(file_count,n,m,o)
        if number == 3:
            GenericStuff.no_ask(file_count,n,m,o)
        if number == 4:
            GenericStuff.ask_not_in_tell(file_count,n,m,o)
        if number == 5:
            GenericStuff.only_terminal_tell(file_count,n,m,o)
        if number == 6:
            GenericStuff.only_single_horned_tell(file_count,n,m,o)
        if number == 7:
            GenericStuff.only_conjunction_horned_tell(file_count,n,m,o)
        if number == 8:
            GenericStuff.only_terminal_and_single_horned_tell(file_count,n,m,o)
        if number == 9:
            GenericStuff.only_terminal_and_conjuction_horned_tell(file_count,n,m,o)
        if number == 10:
            GenericStuff.only_conjuction_and_single_horned_tell(file_count,n,m,o)
        if number == 11:
            GenericStuff.multi_conjuction_and_everything(file_count,n,m,o,multi)




def main():
    All = sys.argv[1]
    number2 = sys.argv[2]
    FileCount = sys.argv[3]
    number4 = sys.argv[4]
    number5 = sys.argv[5]
    number6 = sys.argv[6]
    number7 = sys.argv[7]

    

    """
    print("Do you want to make generic testcase or Special ones for KB?")   
    Generic = bool(input("Type T for normal and F for loading KB special case:  "))
    if(Generic):
    """
    if (str(All).lower() == "generic"):
        TestCaseType = number2  
        TotalPrepositionSymbolCount = number4 
        TotalSingleHornedClauseCount = number5 
        TotalConjuectionHornedClauseCount = number6 
        TotalMultiConjuctionHornedClauseCount = number7   
        choose_edge_case(TestCaseType, FileCount, TotalPrepositionSymbolCount, TotalSingleHornedClauseCount, TotalConjuectionHornedClauseCount, TotalMultiConjuctionHornedClauseCount)
        print("All files have been made! Press Enter to exit!")

    elif(str(All).lower() == "h" or str(All).lower() == "help"):
        CmdHelpLine.genericHelp()
        
    elif(str(number2).lower() == "h" or str(number2).lower() == "help"):
        CmdHelpLine.TestCaseHelp()
        
    else:
        """
        Here TotalSingleHornedClause will be carrying bool info on whether parenthesis or not
        """
        symbolCountPerBox = number2
        parenthesis = number4 
        negationOrNotOrMixed = number5 
        ConjunctOrDisjunctOrBothOrNone = number6
        ImplicationOrBiconditionalOrBothOrNone = number7

        KBTestStuff.make_edge_case_for_KB(symbolCountPerBox, FileCount, TotalPrepositionSymbolCount, parenthesis, negationOrNotOrMixed, ConjunctOrDisjunctOrBothOrNone, ImplicationOrBiconditionalOrBothOrNone)
        

        
        print("How should parenthesis should exist?:")
        print("1.None")
        print("2.Set up to only encase literals")
        parenthesis1 = int(input("Please choose the number"))
        """
        choose_parenthesis_case_for_KB()
        """
        print(parenthesis1)
        

        print("All files have been made! Press Enter to exit!")


       
    

if __name__ == "__main__":
    main()
