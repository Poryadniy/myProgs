import requests
import time

from bs4 import BeautifulSoup

def parse(Currency):

    URL = ''
    if(Currency == "usd"):
        URL = 'https://www.banki.ru/products/currency/usd/'

    else:
        URL = 'https://www.banki.ru/products/currency/eur/'
    #HEADERS = {
            #'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.63 Safari/537.36'
    #}

    response = requests.get(URL)#, headers = HEADERS)
    soup = BeautifulSoup(response.content, 'html.parser')
    items = soup.findAll('div',class_ = 'currency-table')
    comps = []


    for item in items:
        comps.append({
            'title' : item.find('div',class_ = 'currency-table__large-text').get_text(strip = True)
        })
    for comp in comps:
        return (comp['title'])


#parse(Currency)

