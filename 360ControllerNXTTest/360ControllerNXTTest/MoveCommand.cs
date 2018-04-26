using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360ControllerNXTTest
{
    enum MoveCommandType
    {
        BLANK,
        MOVE_UP,
        MOVE_DOWN,
        MOVE_LEFT,
        MOVE_RIGHT,
        OPEN_CLAW,
        CLOSE_CLAW
    }

    struct CommandObject
    {
        public char motorNum;
        public int power;
        public int duration;
    }

    class MoveCommand
    {
        public int duration;
        int power;
        MoveCommandType type;


        public MoveCommand(MoveCommandType initType, int durationInit, int powerInit)
        {
            duration = durationInit;
            power = powerInit;
            type = initType;
        }

        // returns a CommandObject struct from this command for the robot to execute
        public CommandObject Execute()
        {
            CommandObject cobj;
            cobj.duration = this.duration;
            if (this.type == MoveCommandType.MOVE_LEFT ||
                this.type == MoveCommandType.MOVE_DOWN ||
                this.type == MoveCommandType.CLOSE_CLAW)
            {
                cobj.power = -1 * this.power;
            }
            if(this.type == MoveCommandType.BLANK)
            {
                throw new Exception("Cannot execute a blank command. Please initialize it first.");
            }
            else
            {
                cobj.power = this.power;
            }

            switch(this.type)
            {
                case MoveCommandType.MOVE_UP:
                    cobj.motorNum = 'B';
                    break;
                case MoveCommandType.MOVE_DOWN:
                    cobj.motorNum = 'B';
                    break;
                case MoveCommandType.MOVE_LEFT:
                    cobj.motorNum = 'A';
                    break;
                case MoveCommandType.MOVE_RIGHT:
                    cobj.motorNum = 'A';
                    break;
                case MoveCommandType.OPEN_CLAW:
                    cobj.motorNum = 'C';
                    break;
                case MoveCommandType.CLOSE_CLAW:
                    cobj.motorNum = 'C';
                    break;
                default:
                    throw new Exception("Unknown or unspecified command type");
            }

            return cobj;
        }

        public MoveCommandType GetCommandType()
        {
            return type;
        }

        public void SetCommandType(MoveCommandType newType)
        {
            this.type = newType;
        }
        

    }
}
