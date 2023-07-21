import string
import random

def genericHelp():
        print("Generic help function:")
        print("the parameters will be listed in following format")
        print("<filename> <TestCaseTypeNo> <TestCaseTotalFileCount> <TotalPrepositionSymbolCount> <TotalSingleHornedClauseCount> <TotalConjuectionHornedClauseCount> <TotalMultiConjuctionHornedClauseCount>")

def TestCaseHelp():
        print("TestCaseType help function:")
        print("the following number will correspond to the following test cases")
        print("1.Standard file setup")
        print("2.Set up file with no TELL info")
        print("3.Set up file with no ASK info")
        print("4.Set up file with ASK info not exisitng in TELL info")
        print("5.Set up file with only terminal nodes in TELL info")
        print("6.Set up file with only single horned clause info")
        print("7.Set up file with only Conjuction horned clause info")
        print("8.Set up file with only single horned clause and terminal info")
        print("9.Set up file with only Conjuction horned clause and terminal info")
        print("10.Set up file with only Conjuction horned clause and single horned clause info")
        print("11.Set up file with multi Conjuction horned clause and everything else info")
