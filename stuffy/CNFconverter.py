import sys

def conjunction(lhs, rhs):
    outputString = str(lhs + " " + rhs)
    return lhs and rhs 


def disjunction(lhs, rhs):
    outputString = str(lhs + " " + rhs)
    return lhs or rhs


def negation(lhs, rhs):
    return not rhs


def implication(lhs, rhs):
    return not lhs or rhs


def biconditional(lhs, rhs):
    return implication(lhs, rhs) and implication(rhs, lhs)


KB = {'p2 => p3', 'p3 => p1', 'c => e', 'b & e => f', 'f & g => h', 'p1 => d', 'p1 & p3 => c', 'a', 'b', 'p2'}
Q = 'p'
OPS = {'~': negation, '&': conjunction, '||': disjunction,  '=>': implication, '<=>': biconditional}  # In order of
# precedence
# print(tt_entail(KB, Q))


def pl_recurse(sentence, interpretation):
    i = 0
    while i < len(sentence):
        if sentence[i] in OPS.keys():
            lhs = sentence[i - 1]
            rhs = sentence[i + 1]
            if lhs not in (True, False):
                lhs = interpretation[lhs]
            if rhs not in (True, False):
                rhs = interpretation[rhs]
            sentence[i + 1] = OPS[sentence[i]](lhs, rhs)
            i += 2
        else:
            sentence[i] = interpretation[sentence[i]]
            i += 1
    return sentence[len(sentence) - 1]


# Atomic model checking
def pl_true(sentence, interpretation):
    for i, sentence in enumerate(sentence):
        sequence = sentence.split()
        if not pl_recurse(sequence, interpretation):
            return False
    return True


def main(file):
	with open("assignments.txt", "w") as output_file:
            output_file.write("Test")
            
	
        
        

   
if __name__ == "__main__":
    main(sys.argv[1])