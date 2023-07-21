# The query function, callable by client
from time import time


def conjunction(lhs, rhs):
    return lhs and rhs


def disjunction(lhs, rhs):
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


# The solver, callable by the query encapsulation
def tt_check(kb, alpha, symbols, model):
    if not symbols:
        if pl_true(kb, model):
            return pl_true({alpha}, model)
        else:
            return True
    else:
        stack = list(symbols)  # Make a list-copy of the set symbols, this allows for backtracking
        # Get the last element and remove it
        p = stack.pop()

        tmp_model = model.copy()
        model[p] = True
        tmp_model[p] = False
        # rest = symbols
        return tt_check(kb, alpha, stack, model) and tt_check(kb, alpha, stack, tmp_model)


def tt_entail(kb, alpha):
    symbols = {word for line in kb for word in line.split()} - OPS.keys() | \
              {word for word in set(alpha.split())} - OPS.keys()
    return tt_check(kb, alpha, symbols, {})


t0 = time()
ans = tt_entail(KB, Q)
t1 = time()
print(f'Computed = {ans} in {t1 - t0} seconds.')
