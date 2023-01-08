// contracts/OurToken.sol
// SPDX-License-Identifier: MIT
pragma solidity >=0.6.0 <0.8.0;

import "@openzeppelin/contracts/token/ERC20/ERC20.sol";

contract OurToken is ERC20 {
    constructor(uint256 initialSupply) public ERC20("ENTRToken", "ENTR") {
        _mint(msg.sender, initialSupply);
    }
}
