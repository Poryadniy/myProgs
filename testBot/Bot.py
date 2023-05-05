from aiogram import Bot, types
from aiogram.dispatcher import Dispatcher
from aiogram.utils import executor
import requests
from bs4 import BeautifulSoup
import parser

import os


bot = Bot(token = '5275353351:AAGzHTlb8XDu4S7VwLfCufEKUtD7JBQjKRg')
dp = Dispatcher(bot)


'''*********************************КЛИЕНТСКАЯ ЧАСТЬ*********************************'''
@dp.message_handler(commands = ['start','help'])
async def command_start(message : types.Message):
	await message.answer("Hello, you can use commands which are bellow:\n1.Exchange rate\n2.Finance news\n3.Facts")







'''*********************************АДМИН ЧАСТЬ*********************************'''

'''*********************************ОБЩАЯ ЧАСТЬ*********************************'''

@dp.message_handler()

async def echo_send(message : types.Message):

	if(message.text == "1"):
		await message.answer("What exchange rate do you want to know ?\n1.USA Dollar(usd)\n2.Euro(eur)")
	if(message.text == "usd"):
		await message.answer(parser.parse('usd') + " Р")
	if(message.text == "eur"):
		await message.answer(parser.parse('eur') + " Р")



		#await message.answer(parser.parse() + " Р")
	





	
    #await message.reply(message.text)
    #await bot.send_message(message.from_user.id, message.text)

        



executor.start_polling(dp, skip_updates = True)