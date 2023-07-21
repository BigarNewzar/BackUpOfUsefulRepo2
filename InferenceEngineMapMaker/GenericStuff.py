import random
import BaseLevelStuff

def normal(file_count,n,m,o):
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
        

        prepoTracklist = BaseLevelStuff.make_random_symbols(n, prepoTracklist)

        case1 = BaseLevelStuff.make_random_single_horned(m, prepoTracklist, templist, case1)

        case1 = BaseLevelStuff.make_random_conjuction_horned(o, prepoTracklist, templist, case1)
        
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
    
def no_tell(file_count,n,m,o):
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

        f = open("testNoTell"+str(x)+".txt",'w')   
        
        """
        PrepoTrackList will keep track of all the prepositions made for that file
        case1 will be used to store all the horn clauses and prepositions and will be passed to that file
        templist will be used to juggle around the lists accordingly for that file
        """ 

        prepoTracklist = []                
             

        prepoTracklist = BaseLevelStuff.make_random_symbols(n, prepoTracklist)       

        """These are testing stuff
        print("TELL")
        print(case1)   
        print("ASK")
        """

        k = random.choice(prepoTracklist)

        """These are testing stuff
        print(k)
        """
    
        """
        The section below will write the information to the file
        """
        f.write("TELL \n")        
        f.write("\nASK\n")
        f.write(k)

def no_ask(file_count,n,m,o):
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

        f = open("testNoASK"+str(x)+".txt",'w')   
        
        
        
        """
        PrepoTrackList will keep track of all the prepositions made for that file
        case1 will be used to store all the horn clauses and prepositions and will be passed to that file
        templist will be used to juggle around the lists accordingly for that file
        """ 

        prepoTracklist = []    
        case1 = []
        templist = []
        
        
       

        prepoTracklist = BaseLevelStuff.make_random_symbols(n, prepoTracklist)

        case1 = BaseLevelStuff.make_random_single_horned(m, prepoTracklist, templist, case1)

        case1 = BaseLevelStuff.make_random_conjuction_horned(o, prepoTracklist, templist, case1)
        
        case1 = BaseLevelStuff.list_out_terminal(prepoTracklist, case1)
       

        """These are testing stuff
        print("TELL")
        print(case1)   
        print("ASK")
        """

        
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
        
def ask_not_in_tell(file_count,n,m,o):
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

        f = open("testAskNotInTell"+str(x)+".txt",'w')   
        
        
        """
        PrepoTrackList will keep track of all the prepositions made for that file
        case1 will be used to store all the horn clauses and prepositions and will be passed to that file
        templist will be used to juggle around the lists accordingly for that file
        """ 

        prepoTracklist = []    
        case1 = []
        templist = []
        

        prepoTracklist = BaseLevelStuff.make_random_symbols(n, prepoTracklist)

        case1 = BaseLevelStuff.make_random_single_horned(m, prepoTracklist, templist, case1)

        case1 = BaseLevelStuff.make_random_conjuction_horned(o, prepoTracklist, templist, case1)
        
        case1 = BaseLevelStuff.list_out_terminal(prepoTracklist, case1)
       

        """These are testing stuff
        print("TELL")
        print(case1)   
        print("ASK")
        """

        k = random.make_random_single_symbol()

        while k in prepoTracklist:
             k = random.make_random_single_symbol()

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

def only_terminal_tell(file_count,n,m,o):
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

        f = open("testOnlyTerminalTell"+str(x)+".txt",'w')   
        
        
        """
        PrepoTrackList will keep track of all the prepositions made for that file
        case1 will be used to store all the horn clauses and prepositions and will be passed to that file
        templist will be used to juggle around the lists accordingly for that file
        """ 

        prepoTracklist = []    
        case1 = []
        
        
        
       

        prepoTracklist = BaseLevelStuff.make_random_symbols(n, prepoTracklist)
        
        case1 = BaseLevelStuff.list_out_terminal(prepoTracklist, case1)
       

        """These are testing stuff
        print("TELL")
        print(case1)   
        print("ASK")
        """

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

def only_single_horned_tell(file_count,n,m,o):
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

        f = open("testOnlySingleHornedTell"+str(x)+".txt",'w')   
        
        
        """
        PrepoTrackList will keep track of all the prepositions made for that file
        case1 will be used to store all the horn clauses and prepositions and will be passed to that file
        templist will be used to juggle around the lists accordingly for that file
        """ 

        prepoTracklist = []    
        case1 = []
        templist = []
        
       
        
        prepoTracklist = BaseLevelStuff.make_random_symbols(n, prepoTracklist)

        case1 = BaseLevelStuff.make_random_single_horned(m, prepoTracklist, templist, case1)        
       

        """These are testing stuff
        print("TELL")
        print(case1)   
        print("ASK")
        """

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

def only_conjunction_horned_tell(file_count,n,m,o):
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

        f = open("testOnlyConjunctionHornedTell"+str(x)+".txt",'w')   
        
        
        """
        PrepoTrackList will keep track of all the prepositions made for that file
        case1 will be used to store all the horn clauses and prepositions and will be passed to that file
        templist will be used to juggle around the lists accordingly for that file
        """ 

        prepoTracklist = []    
        case1 = []
        templist = []
        
        
       

        prepoTracklist = BaseLevelStuff.make_random_symbols(n, prepoTracklist)

        case1 = BaseLevelStuff.make_random_conjuction_horned(o, prepoTracklist, templist, case1)
               

        """These are testing stuff
        print("TELL")
        print(case1)   
        print("ASK")
        """

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

def only_terminal_and_single_horned_tell(file_count,n,m,o):
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

        f = open("testOnlyTerminalAndSingleHornedTell"+str(x)+".txt",'w')   
        
        
        """
        PrepoTrackList will keep track of all the prepositions made for that file
        case1 will be used to store all the horn clauses and prepositions and will be passed to that file
        templist will be used to juggle around the lists accordingly for that file
        """ 

        prepoTracklist = []    
        case1 = []
        templist = []
        
        
            

        prepoTracklist = BaseLevelStuff.make_random_symbols(n, prepoTracklist)

        case1 = BaseLevelStuff.make_random_single_horned(m, prepoTracklist, templist, case1)        
        
        case1 = BaseLevelStuff.list_out_terminal(prepoTracklist, case1)
       

        """These are testing stuff
        print("TELL")
        print(case1)   
        print("ASK")
        """

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

def only_terminal_and_conjuction_horned_tell(file_count,n,m,o):
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

        f = open("testOnlyTerminalAndConjunctionHornedTell"+str(x)+".txt",'w')   
        
        
        """
        PrepoTrackList will keep track of all the prepositions made for that file
        case1 will be used to store all the horn clauses and prepositions and will be passed to that file
        templist will be used to juggle around the lists accordingly for that file
        """ 

        prepoTracklist = []    
        case1 = []
        templist = []
        
        

        prepoTracklist = BaseLevelStuff.make_random_symbols(n, prepoTracklist)
       
        case1 = BaseLevelStuff.make_random_conjuction_horned(o, prepoTracklist, templist, case1)
        
        case1 = BaseLevelStuff.list_out_terminal(prepoTracklist, case1)
       

        """These are testing stuff
        print("TELL")
        print(case1)   
        print("ASK")
        """

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

def only_conjuction_and_single_horned_tell(file_count,n,m,o):
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

        f = open("testOnlyConjunctionAndSingleHornedTell"+str(x)+".txt",'w')   
        
        
        """
        PrepoTrackList will keep track of all the prepositions made for that file
        case1 will be used to store all the horn clauses and prepositions and will be passed to that file
        templist will be used to juggle around the lists accordingly for that file
        """ 

        prepoTracklist = []    
        case1 = []
        templist = []
        
        
       

        prepoTracklist = BaseLevelStuff.make_random_symbols(n, prepoTracklist)

        case1 = BaseLevelStuff.make_random_single_horned(m, prepoTracklist, templist, case1)

        case1 = BaseLevelStuff.make_random_conjuction_horned(o, prepoTracklist, templist, case1)
        

        """These are testing stuff
        print("TELL")
        print(case1)   
        print("ASK")
        """

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

def multi_conjuction_and_everything(file_count,n,m,o,multi):

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

        f = open("testMultiConjunctionAndEverything"+str(x)+".txt",'w')   
        
        
        """
        PrepoTrackList will keep track of all the prepositions made for that file
        case1 will be used to store all the horn clauses and prepositions and will be passed to that file
        templist will be used to juggle around the lists accordingly for that file
        """ 

        prepoTracklist = []    
        case1 = []
        templist = []

        prepoTracklist = BaseLevelStuff.make_random_symbols(n, prepoTracklist)

        case1 = BaseLevelStuff.make_random_single_horned(m, prepoTracklist, templist, case1)

        case1 = BaseLevelStuff.make_random_multi_conjuction_horned(o, prepoTracklist, templist, case1,multi)
        
        

        """These are testing stuff
        print("TELL")
        print(case1)   
        print("ASK")
        """

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
    
