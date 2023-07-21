
import BareBone
import random   

def make_random_KB_symbols(count,prepoTracklist, negationOrNotOrMixed):
    
        for x in range(count): 
            if(negationOrNotOrMixed == "0"):                         
                c = BareBone.make_only_positive_literals_for_KB 
            if(negationOrNotOrMixed == "1"):                         
                c = BareBone.make_random_literals_for_KB 
            if(negationOrNotOrMixed == "2"):                         
                c = BareBone.make_only_negative_literals_for_KB                      
            prepoTracklist.append(c)
        
        return prepoTracklist

def mix_KB_elements_with_logic_connectives(symbolCountPerBox, prepoTracklist, templist, case1, ConjunctOrDisjunctOrBothOrNone, ImplicationOrBiconditionalOrBothOrNone, parenthesis):
        for x in prepoTracklist:            
            templist = random.sample(prepoTracklist,symbolCountPerBox)

            elementolist = []
            elementolist2 = []

            for element in templist:
                if(ConjunctOrDisjunctOrBothOrNone == "1"):
                    k = random.randint(1,9)
                    if(k >5):                                              
                            if(ImplicationOrBiconditionalOrBothOrNone == "1"):
                                elementolist2.append(element + " =>")
                            elif(ImplicationOrBiconditionalOrBothOrNone == "2"):
                                elementolist2.append(element + " <=>")
                            elif(ImplicationOrBiconditionalOrBothOrNone == "3"):
                                p = random.randint(1,9)
                                if(p >5):
                                    elementolist2.append(element + " =>")
                                else:
                                    elementolist2.append(element + " <=>")  
                            else:
                                continue  
                    else:
                        elementolist.append(element + " &&") 

                elif(ConjunctOrDisjunctOrBothOrNone == "2"):
                    k = random.randint(1,9)
                    if(k >5):                                              
                            if(ImplicationOrBiconditionalOrBothOrNone == "1"):
                                elementolist2.append(element + " =>")
                            elif(ImplicationOrBiconditionalOrBothOrNone == "2"):
                                elementolist2.append(element + " <=>")
                            elif(ImplicationOrBiconditionalOrBothOrNone == "3"):
                                p = random.randint(1,9)
                                if(p >5):
                                    elementolist2.append(element + " =>")
                                else:
                                    elementolist2.append(element + " <=>")  
                            else:
                                continue  
                    else:
                        elementolist.append(element + " ||")
                elif(ConjunctOrDisjunctOrBothOrNone == "3"):
                    k = random.randint(1,9)
                    if(k >5):                                              
                            if(ImplicationOrBiconditionalOrBothOrNone == "1"):
                                elementolist2.append(element + " =>")
                            elif(ImplicationOrBiconditionalOrBothOrNone == "2"):
                                elementolist2.append(element + " <=>")
                            elif(ImplicationOrBiconditionalOrBothOrNone == "3"):
                                p = random.randint(1,9)
                                if(p >5):
                                    elementolist2.append(element + " =>")
                                else:
                                    elementolist2.append(element + " <=>")  
                            else:
                                continue  
                    else:
                        y = random.randint(1,9)
                        if(y >5):
                            elementolist.append(element + " &&")
                        else:
                            elementolist.append(element + " ||") 
                else:
                    continue 

            elementolistFinal = []

            for element in templist:
                if(parenthesis == 1):
                     for x in elementolist:
                        elementolistFinal.append("(" + x + ")")                           
                else:
                    elementolistFinal.append(x)  
                newlist = " ".join(elementolistFinal)

                case1.append(newlist +" "+ templist[1]+"; ")
            return case1

                                                           

def make_random_symbols(count,prepoTracklist):
    
        for x in range(count):                          
            c = BareBone.make_random_single_symbol()                      
            prepoTracklist.append(c)

        return prepoTracklist
        
def make_random_single_horned(count, prepoTracklist, templist, case1):
            for y in range(count):            
                templist = random.sample(prepoTracklist,2)
                k = templist[0]
                i = templist[1]        
            
                """These are testing stuff
                print(k, "=>",i, "; ")
                """
            
                case1.append(k + " => " + i + "; ")
            return case1

def make_random_conjuction_horned(count, prepoTracklist, templist, case1):
            for z in range(count):
                templist = random.sample(prepoTracklist,3)
                k = templist[0]
                i = templist[1]
                j = templist[2]

                """These are testing stuff
                print(k, "&",j,"=>",i, "; ")
                """
            
                case1.append(k + "&" + j + " => " + i + "; ")
            return case1

def make_random_multi_conjuction_horned(count, prepoTracklist, templist, case1,multicount):
            for z in range(count):
                templist = random.sample(prepoTracklist,multicount)
                """
                as long as element exists in list, pass them to variables...for each variables
                inject them "with &", for the last case, store is as "=> and i and ;"
                """
                k = templist.pop(0)
                j = templist.pop()
                elementolist = []

                for element in templist:
                    elementolist.append(element + " &")

                newlist = " ".join(elementolist)

                case1.append(newlist +" "+ j + " => " + k + "; ")
            return case1

def list_out_terminal(prepoTracklist, case1):
            for l in prepoTracklist:
                """These are testing stuff
                print(l, ";")   
                """
                case1.append(l + "; ")
            return case1
