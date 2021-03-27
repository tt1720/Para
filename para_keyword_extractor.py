import nltk
#nltk.download()
from nltk import tokenize
from nltk.corpus import stopwords
from nltk.tokenize import word_tokenize 
import math
import operator

##Loading a file
#file = open("C:\data.txt", "rt")
#data = file.read()

#text input
textInput = input()

#word count
words = textInput.split()

#words to be disregarded from being keywords
stop_words = set(stopwords.words("english"))

#tokenize into sentences
sentences = tokenize.sent_tokenize(textInput)
total_sent_len = len(sentences)

def removePunc(word):
    word = word.replace(".","")
    word = word.replace(",","")
    word = word.replace(";","")
    word = word.replace(":","")
    word = word.replace("\"","")
    word = word.replace("\n","")
    word = word.replace(")","")
    word = word.replace("(","")
    word = word.replace("?","")
    word = word.replace("!","")
    word = word.replace("/","")
    word = word.lower()
    return word

TF = {}
for i in words:
    i=removePunc(i)
    if i not in stop_words:
        if i in TF:
            TF[i] += 1
        else:
            TF[i] = 1
TF.update((x, y/int(len(words))) for x, y in TF.items())


def checkWord(word,sentences):
    """input is word to check and list of sentence to check it.
    checks the sentence for whether the word is inside the sentence"""
    exist = 0
    for i in sentences:
        sentWords=i.split()
        for j in sentWords:
            j=removePunc(j)
            if word == j:
                exist += 1
                break
    return (exist)

IDF = {}
for i in words:
    i = removePunc(i)
    if i not in stop_words:
        exist = checkWord(i,sentences)
        IDF[i] = math.log(int(total_sent_len)/exist)


TFIDF = {key: TF[key] * IDF[key] for key in TF.keys()}

def Keywords(n):
    """lists n keywords with highest TFIDF score"""
    sortedKeywords = sorted(TFIDF.items(), key=operator.itemgetter(1))[-n:]
    return sortedKeywords

keywords = Keywords(5)

for i in keywords:
    print (i[0])