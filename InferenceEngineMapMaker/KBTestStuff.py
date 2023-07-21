import random
import BaseLevelStuff

def make_edge_case_for_KB(symbolCountPerBox,file_count, n, parenthesis, negationOrNotOrMixed, ConjunctOrDisjunctOrBothOrNone, ImplicationOrBiconditionalOrBothOrNone):
        
    """
        Exisiting info will get overridden by this, so beware. The method below will basically make and input stuff to files
        f is basically for file

        filecount will be used to determine how many files will be created
        
    """    

    for x in range (file_count):

        """
        f will be used to make file. Here it will make files with names test[x].txt where x is a number 
        Note: "[" and "]" used above was only to emphasize and actual file name will be more like test4.txt or smth
        """

        f = open("testNormal"+str(x)+".txt",'w')   
        
        
        """
        PrepoTrackList will keep track of all the prepositions made for that file
        case1 will be used to store all the horn clauses and prepositions and will be passed to that file
        templist will be used to juggle around the lists accordingly for that file
        """ 

        prepoTracklist = []    
        case1 = []
        templist = []          
        

        prepoTracklist = BaseLevelStuff.make_random_KB_symbols(n, prepoTracklist,negationOrNotOrMixed)
        case1 = BaseLevelStuff.mix_KB_elements_with_logic_connectives(symbolCountPerBox,prepoTracklist, templist, case1, ConjunctOrDisjunctOrBothOrNone, ImplicationOrBiconditionalOrBothOrNone, parenthesis)
        
        case1 = BaseLevelStuff.list_out_terminal(prepoTracklist, case1)
       

        k = random.choice(prepoTracklist)

        """These are testing stuff
        print(k)
        """
    
        """
        The section below will write the information to the file
        """

        f.write("TELL \n")
        for c in case1:
            f.write(c)
        f.write("\nASK\n")
        f.write(k)
    
