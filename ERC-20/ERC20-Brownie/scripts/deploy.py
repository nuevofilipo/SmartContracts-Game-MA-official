from brownie import OurToken
from scripts.helpful_scripts import get_account

initial_supply = 1000000000000000000000


def deploy_token():
    account = get_account()
    myToken = OurToken.deploy(initial_supply, {"from": account}, publish_source=True)
    print(f"Contract deployed to {myToken.address}")


def main():
    deploy_token()
