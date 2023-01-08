// SPDX-License-Identifier: MIT
pragma solidity >=0.6.0 <0.8.7;

import "@openzeppelin/contracts/token/ERC20/ERC20.sol";

interface ERC20Token {
    //This interface defines several functions, which are often used when handling ERC-20 Tokens

    function balanceOf(address account) external view returns (uint256);

    function allowance(address owner, address spender)
        external
        view
        returns (uint256);

    function transfer(address recipient, uint256 amount)
        external
        returns (bool);

    function approve(address spender, uint256 amount) external returns (bool);

    function transferFrom(
        address sender,
        address recipient,
        uint256 amount
    ) external returns (bool);
}

contract JuicyGame {
    //Here, variables are defined, as well as the tokens that are used in the functionality of the smart contract

    address public admin = 0xc84577ac220DC5977186b6B690469F4b75358E4E;
    mapping(address => uint256) public playerTimesDeposited;
    address[] public allPlayers;
    mapping(address => uint256) public depositedBalance;

    ERC20Token public BUSD;
    ERC20Token public IGToken;
    ERC20Token public ENTRToken;

    constructor() public {
        //The tokens addresses are assigned to some names
        BUSD = ERC20Token(0xbCe98d116cA02A87a2E6c8EDf9597CEd50f3B0a2);
        IGToken = ERC20Token(0x5f310227dd9a9e65DaEb9d92282E27DD0eFcA02E);
        ENTRToken = ERC20Token(0xBB7DFc1aBbd94d53648e9DF1F7584B898b1D57C2);
    }

    function depositTokens(uint256 amount) public {
        //This function allows to deposit BUSD test-tokens into the Smart Contract called Juicy Game
        uint256 playersUsdcBalance = BUSD.balanceOf(address(msg.sender));
        require(amount > 0, "Amount must be greater than zero");
        require(
            playersUsdcBalance >= amount * 1e18,
            "Not enough tokens in wallet"
        );

        BUSD.transferFrom(msg.sender, address(this), amount * 1e18);
        ENTRToken.transfer(msg.sender, amount * 1e18);

        /*Here are some variables that are utilised to track some data of the player, in the if statement below,
        the players address is added to a list of all players
        */
        depositedBalance[msg.sender] += amount * 1e18;
        playerTimesDeposited[msg.sender]++;

        if (playerTimesDeposited[msg.sender] == 1) {
            allPlayers.push(msg.sender);
        }
    }

    function withdrawalPlayers(uint256 _amount) public {
        /*This function allows the withdrawal of BUSD from the Smart Contract, to check whether the player
        is allowed to withdraw their tokens, the balance of the InGame-Token (IGToken) is checked
        */

        uint256 dexBalance = BUSD.balanceOf(address(this));
        uint256 playersBalance = IGToken.balanceOf(address(msg.sender));

        require(playersBalance >= _amount, "Not enough tokens in wallet");
        require(_amount <= dexBalance, "Not enough tokens in reserve");

        BUSD.transfer(msg.sender, _amount);
        ENTRToken.transferFrom(msg.sender, address(this), _amount);
        IGToken.transferFrom(msg.sender, admin, _amount);

        depositedBalance[msg.sender] = 0;
    }

    function timesDeposited(address _address) public view returns (uint256) {
        //This function is used in order to check the amount of times a player already deposit/played the game
        return playerTimesDeposited[address];
    }
}
