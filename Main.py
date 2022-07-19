"""
JASP: Just Another Simple Platformer

Built using Python, the Arcade library, and the Tilemaps editor

Developed by GearFox
"""

# Imports
import arcade

# Constants
kScreenWidth = 1000
kScreenHeight = 650
kScreenTitle = "JASP"

kCharacterScaling = 1
kTileScaling = 0.5

class MyGame(arcade.Window):
    """
    The Class for the main application
    """

    def __init__(self):

        # Super screen dimensions to parent window class
        # and setup the rest of the window
        super().__init__(kScreenWidth, kScreenHeight, kScreenTitle)

        # Sprite lists
        self.wallList = None
        self.playerList = None

        # Player sprite
        self.playerSprite = None

        arcade.set_background_color(arcade.csscolor.CORAL)

    def setup(self):
        """
        Setup the game here, calls every program restart
        """
        # Create the player sprite
        self.playerList = arcade.SpriteList()
        self.wallList = arcade.SpriteList(use_spatial_hash=True)

        # Set up the player, specifically placing it at the starting cords
        imageSource = ":resources:images/animated_characters/female_adventurer/femaleAdventurer_idle.png"
        self.playerSprite = arcade.Sprite(imageSource, kCharacterScaling)
        self.playerSprite.center_x = 64
        self.playerSprite.center_y = 128
        self.playerList.append(self.playerSprite)

        # Create the ground
        for x in range(0, 1250, 64):
            wall = arcade.Sprite(":resources:images/tiles/grassMid.png", kTileScaling)
            wall.center_x = x
            wall.center_y = 32
            self.wallList.append(wall)

        #Create crates from 2d array
        coordinate_list = [[512, 96], [256, 96], [768, 96]]
        for coordinate in coordinate_list:

            # Loop through coordinates array and add crates
            wall = arcade.Sprite(":resources:images/tiles/boxCrate_double.png", kTileScaling)
            wall.position = coordinate
            self.wallList.append(wall)

    def on_draw(self):
        """
        calls every loop cycle, update the screen
        """

        self.clear()

        self.wallList.draw()
        self.playerList.draw()

def main():
    window = MyGame()
    window.setup()
    arcade.run()

if __name__ == "__main__":
    main()
