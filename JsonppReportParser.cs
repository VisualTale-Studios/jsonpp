#pragma warning disable CS0162
#pragma warning disable CS0164
#pragma warning disable CS8600
#pragma warning disable CS8603
#pragma warning disable CS8604
#pragma warning disable CS8619
#pragma warning disable CS8625
using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
namespace jsonpp;
partial class JsonppReportParser
{
  protected unsafe char* mInput;
  protected int mLength;
  protected int mIndex;
  protected int _R_mIndex;
  private byte[] _input__112843886=new byte[]{1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
  private byte[] _input_304791925=new byte[]{11,0,0,0,0,0,0,0,0,0,16,2,0,0,10,9,9,9,9,9,9,9,9,9,15,0,0,12,0,0,0,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,17,1,18,0,7,0,7,6,7,7,7,5,7,7,7,7,7,7,7,4,7,7,7,7,3,8,7,7,7,7,7,7,13,0,14};
  private byte[] _input_2079713063=new byte[]{1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
  private byte[] _input__1345822948=new byte[]{1,0,0,2,2,2,2,2,2,2,2,2,2};
  private byte[] _input__1626705557=new byte[]{2,0,1,1,1,1,1,1,1,1,1,1};
  private byte[] _input__275241956=new byte[]{2,0,3,3,3,3,3,3,3,3,3,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1};
  private byte[] _input__1363445837=new byte[]{2,2,2,2,2,2,2,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1};
  private byte[] _input_914903567=new byte[]{1,0,3,3,3,3,3,3,3,3,3,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2};
  private byte[] _input_354188981=new byte[]{2,2,2,2,2,2,2,2,2,2,0,0,0,0,0,0,0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,0,0,0,0,2,0,2,2,3,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,2,2,2,2,2,2};
  private byte[] _input_2105018830=new byte[]{1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,1,1,1,1,1,1,1,1};
  private byte[] _input_1827613293=new byte[]{1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1,0,1,1,1,1,1,1,1,1,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
  private byte[] _input_1914441493=new byte[]{1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,2,1,1,1,1,1,1,1,1,1,1,1,1};
  private byte[] _input_814843533=new byte[]{1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1,0,1,1,1,1,1,1,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
  private byte[] _input_741719107=new byte[]{2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
  private byte[] _input__2091565114=new byte[]{1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1,0,1,1,1,1,1,1,1,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
  private byte[] _input_1235509320=new byte[]{1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1,0,1,1,1,1,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
  private byte[] _input_1054697671=new byte[]{1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1,0,1,1,1,1,1,1,1,1,1,1,1,1,2,1,1,1,1,1,1,1,1,1,1,1,1,1};
  private byte[] _input_882223330=new byte[]{1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1,0,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
  private byte[] _input_648599790=new byte[]{1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,1,1,1,1,1};
  private byte[] _input_290613082=new byte[]{2,2,2,2,2,2,2,2,2,2,0,0,0,0,0,0,0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,0,0,0,0,2,0,2,2,2,2,2,2,2,2,2,2,2,3,1,2,2,2,2,2,2,2,2,2,2,2,2,2};
  private byte[] _input_1427023098=new byte[]{1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1,0,1,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
  private byte[] _input_1929633164=new byte[]{1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1,0,1,1,1,1,1,1,1,1,1,1,1,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
  private byte[] _input_74199665=new byte[]{1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,1,1,1,1,1,1,1};
  private byte[] _input__1634243735=new byte[]{1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,1,1,1,1,1,1,1,1,1,1,1};
  private byte[] _input_1294486864=new byte[]{3,0,4,4,4,4,4,4,4,4,4,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1};
  private byte[] _input_548224306=new byte[]{0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1};
  private byte[] _input__1223601924=new byte[]{0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2};
  private byte[] _input__58397204=new byte[]{1,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2};
  private byte[] _input__1675836692=new byte[]{1,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1};
  private byte[] _input_490290302=new byte[]{0,1,1,1,1,1,1,1,1,1,0};
  private byte[] _input_119682859=new byte[]{1,0,0,0,0,2};
  private readonly Dictionary<ushort,int> __tags=new(){{3,1},{4,1},{5,1},{6,1},{7,1},{9,1},{10,1},{11,1},{13,3},{14,3}};
  #region Match
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  protected unsafe virtual Match Match(bool close,bool add=true)
  {
    _R_mIndex=mIndex;
    if(!close)Skip();
    ushort token=0,c=0;
    int startIndex=mIndex;
    Match match=default;
    switch((c=mInput[mIndex++])<=125&&c>=34?_input_304791925[c-34]:0)
    {
      case 1:
        //60->61
        if(!((c=mInput[mIndex++])==117)){if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
        //61->62
        if(!(((c=mInput[mIndex++])<=122&&c>=48?_input__112843886[c-48]:0)!=0)){if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
        //62->63
        if(!(((c=mInput[mIndex++])<=122&&c>=48?_input__112843886[c-48]:0)!=0)){if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
        //63->64
        if(!(((c=mInput[mIndex++])<=122&&c>=48?_input__112843886[c-48]:0)!=0)){if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
        //64->0
        if(!(((c=mInput[mIndex++])<=122&&c>=48?_input__112843886[c-48]:0)!=0)){if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
        token=6;
        goto LB_0;
      case 2:
        //57->58
        if(!(((c=mInput[mIndex++])<=57&&c>=48)==true)){if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
        token=3;
        switch((c=mInput[mIndex++])<=101&&c>=46?_input__275241956[c-46]:0)
        {
          case 1:
            goto LB_14;
          case 2:
            //59->10
            if(!(((c=mInput[mIndex++])<=57&&c>=48)==true)){if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
            token=3;
            goto LB_10;
          case 3:
            token=3;
            goto LB_5;
          default:
            {if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
            break;
        }
        break;
      case 3:
        token=2;
        switch((c=mInput[mIndex++])<=122&&c>=48?_input_354188981[c-48]:0)
        {
          case 1:
            token=2;
            switch((c=mInput[mIndex++])<=122&&c>=48?_input_2105018830[c-48]:0)
            {
              case 1:
                token=2;
                break;
              case 2:
                token=2;
                switch((c=mInput[mIndex++])<=122&&c>=48?_input_1827613293[c-48]:0)
                {
                  case 1:
                    token=2;
                    break;
                  case 2:
                    token=2;
                    switch((c=mInput[mIndex++])<=122&&c>=48?_input_1914441493[c-48]:0)
                    {
                      case 1:
                        token=2;
                        break;
                      case 2:
                        token=2;
                        switch((c=mInput[mIndex++])<=122&&c>=48?_input_814843533[c-48]:0)
                        {
                          case 1:
                            token=2;
                            break;
                          case 2:
                            token=19;
                            switch((c=mInput[mIndex++])<=122?_input_741719107[c]:0)
                            {
                              case 1:
                                token=2;
                                break;
                              case 2:
                                token=19;
                                goto LB_0;
                              default:
                                {if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
                                break;
                            }
                            break;
                          default:
                            {if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
                            break;
                        }
                        break;
                      default:
                        {if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
                        break;
                    }
                    break;
                  default:
                    {if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
                    break;
                }
                break;
              default:
                {if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
                break;
            }
            break;
          case 2:
            token=2;
            break;
          case 3:
            token=2;
            switch((c=mInput[mIndex++])<=122&&c>=48?_input__2091565114[c-48]:0)
            {
              case 1:
                token=2;
                break;
              case 2:
                token=2;
                switch((c=mInput[mIndex++])<=122&&c>=48?_input_1235509320[c-48]:0)
                {
                  case 1:
                    token=2;
                    break;
                  case 2:
                    token=2;
                    switch((c=mInput[mIndex++])<=122&&c>=48?_input_1054697671[c-48]:0)
                    {
                      case 1:
                        token=2;
                        break;
                      case 2:
                        token=2;
                        switch((c=mInput[mIndex++])<=122&&c>=48?_input_882223330[c-48]:0)
                        {
                          case 1:
                            token=2;
                            break;
                          case 2:
                            token=16;
                            switch((c=mInput[mIndex++])<=122?_input_741719107[c]:0)
                            {
                              case 1:
                                token=2;
                                break;
                              case 2:
                                token=16;
                                goto LB_0;
                              default:
                                {if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
                                break;
                            }
                            break;
                          default:
                            {if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
                            break;
                        }
                        break;
                      default:
                        {if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
                        break;
                    }
                    break;
                  default:
                    {if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
                    break;
                }
                break;
              default:
                {if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
                break;
            }
            break;
          default:
            {if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
            break;
        }
        break;
      case 4:
        token=2;
        switch((c=mInput[mIndex++])<=122&&c>=48?_input_648599790[c-48]:0)
        {
          case 1:
            token=2;
            break;
          case 2:
            token=2;
            switch((c=mInput[mIndex++])<=122&&c>=48?_input_290613082[c-48]:0)
            {
              case 1:
                token=2;
                switch((c=mInput[mIndex++])<=122&&c>=48?_input_1427023098[c-48]:0)
                {
                  case 1:
                    token=2;
                    break;
                  case 2:
                    token=2;
                    switch((c=mInput[mIndex++])<=122&&c>=48?_input_1235509320[c-48]:0)
                    {
                      case 1:
                        token=2;
                        break;
                      case 2:
                        token=2;
                        switch((c=mInput[mIndex++])<=122&&c>=48?_input_2105018830[c-48]:0)
                        {
                          case 1:
                            token=2;
                            break;
                          case 2:
                            token=20;
                            switch((c=mInput[mIndex++])<=122?_input_741719107[c]:0)
                            {
                              case 1:
                                token=2;
                                break;
                              case 2:
                                token=20;
                                goto LB_0;
                              default:
                                {if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
                                break;
                            }
                            break;
                          default:
                            {if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
                            break;
                        }
                        break;
                      default:
                        {if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
                        break;
                    }
                    break;
                  default:
                    {if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
                    break;
                }
                break;
              case 2:
                token=2;
                break;
              case 3:
                token=2;
                switch((c=mInput[mIndex++])<=122&&c>=48?_input_1929633164[c-48]:0)
                {
                  case 1:
                    token=2;
                    break;
                  case 2:
                    token=9;
                    switch((c=mInput[mIndex++])<=122?_input_741719107[c]:0)
                    {
                      case 1:
                        token=2;
                        break;
                      case 2:
                        token=9;
                        goto LB_0;
                      default:
                        {if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
                        break;
                    }
                    break;
                  default:
                    {if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
                    break;
                }
                break;
              default:
                {if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
                break;
            }
            break;
          default:
            {if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
            break;
        }
        break;
      case 5:
        token=2;
        switch((c=mInput[mIndex++])<=122&&c>=48?_input_882223330[c-48]:0)
        {
          case 1:
            token=2;
            break;
          case 2:
            token=2;
            switch((c=mInput[mIndex++])<=122&&c>=48?_input_1929633164[c-48]:0)
            {
              case 1:
                token=2;
                break;
              case 2:
                token=2;
                switch((c=mInput[mIndex++])<=122&&c>=48?_input_74199665[c-48]:0)
                {
                  case 1:
                    token=2;
                    break;
                  case 2:
                    token=2;
                    switch((c=mInput[mIndex++])<=122&&c>=48?_input_1235509320[c-48]:0)
                    {
                      case 1:
                        token=2;
                        break;
                      case 2:
                        token=11;
                        switch((c=mInput[mIndex++])<=122?_input_741719107[c]:0)
                        {
                          case 1:
                            token=2;
                            break;
                          case 2:
                            token=11;
                            goto LB_0;
                          default:
                            {if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
                            break;
                        }
                        break;
                      default:
                        {if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
                        break;
                    }
                    break;
                  default:
                    {if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
                    break;
                }
                break;
              default:
                {if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
                break;
            }
            break;
          default:
            {if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
            break;
        }
        break;
      case 6:
        token=2;
        switch((c=mInput[mIndex++])<=122&&c>=48?_input__1634243735[c-48]:0)
        {
          case 1:
            token=2;
            break;
          case 2:
            token=2;
            switch((c=mInput[mIndex++])<=122&&c>=48?_input__1634243735[c-48]:0)
            {
              case 1:
                token=2;
                break;
              case 2:
                token=2;
                switch((c=mInput[mIndex++])<=122&&c>=48?_input_1929633164[c-48]:0)
                {
                  case 1:
                    token=2;
                    break;
                  case 2:
                    token=18;
                    switch((c=mInput[mIndex++])<=122?_input_741719107[c]:0)
                    {
                      case 1:
                        token=2;
                        break;
                      case 2:
                        token=18;
                        goto LB_0;
                      default:
                        {if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
                        break;
                    }
                    break;
                  default:
                    {if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
                    break;
                }
                break;
              default:
                {if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
                break;
            }
            break;
          default:
            {if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
            break;
        }
        break;
      case 7:
        token=2;
        break;
      case 8:
        token=2;
        switch((c=mInput[mIndex++])<=122&&c>=48?_input_2105018830[c-48]:0)
        {
          case 1:
            token=2;
            break;
          case 2:
            token=2;
            switch((c=mInput[mIndex++])<=122&&c>=48?_input_648599790[c-48]:0)
            {
              case 1:
                token=2;
                break;
              case 2:
                token=2;
                switch((c=mInput[mIndex++])<=122&&c>=48?_input_1235509320[c-48]:0)
                {
                  case 1:
                    token=2;
                    break;
                  case 2:
                    token=10;
                    switch((c=mInput[mIndex++])<=122?_input_741719107[c]:0)
                    {
                      case 1:
                        token=2;
                        break;
                      case 2:
                        token=10;
                        goto LB_0;
                      default:
                        {if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
                        break;
                    }
                    break;
                  default:
                    {if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
                    break;
                }
                break;
              default:
                {if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
                break;
            }
            break;
          default:
            {if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
            break;
        }
        break;
      case 9:
        token=3;
        switch((c=mInput[mIndex++])<=101&&c>=46?_input__275241956[c-46]:0)
        {
          case 1:
            goto LB_14;
          case 2:
            goto LB_19;
          case 3:
            token=3;
            goto LB_3;
          default:
            {if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
            break;
        }
        break;
      case 10:
        token=3;
        switch((c=mInput[mIndex++])<=120&&c>=46?_input_1294486864[c-46]:0)
        {
          case 1:
            //21->22
            if(!(((c=mInput[mIndex++])<=122&&c>=48?_input__112843886[c-48]:0)!=0)){if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
            //22->0
            if(!(((c=mInput[mIndex++])<=122&&c>=48?_input__112843886[c-48]:0)!=0)){if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
            token=7;
            goto LB_0;
          case 2:
            goto LB_14;
          case 3:
            goto LB_19;
          case 4:
            token=3;
            goto LB_3;
          default:
            {if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
            break;
        }
        break;
      case 11:
        token=8;
        goto LB_0;
      case 12:
        token=15;
        goto LB_0;
      case 13:
        token=17;
        goto LB_0;
      case 14:
        token=21;
        goto LB_0;
      case 15:
        token=22;
        goto LB_0;
      case 16:
        token=23;
        goto LB_0;
      case 17:
        token=24;
        goto LB_0;
      case 18:
        token=25;
        goto LB_0;
      default:
        {if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
        break;
    }
    LB_28:
    //28->28
    if(!(((c=mInput[mIndex++])<=122&&c>=48?_input_2079713063[c-48]:0)!=0)){if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
    token=2;
    goto LB_28;
    LB_14:
    switch((c=mInput[mIndex++])<=57&&c>=45?_input__1345822948[c-45]:0)
    {
      case 1:
        //18->15
        if(!(((c=mInput[mIndex++])<=57&&c>=48)==true)){if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
        token=4;
        goto LB_15;
      case 2:
        token=4;
        goto LB_15;
      default:
        mIndex--;
        goto LB_0;
    }
    LB_19:
    //19->20
    if(!(((c=mInput[mIndex++])<=57&&c>=48)==true)){if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
    token=3;
    //20->10
    if(!(((c=mInput[mIndex++])<=57&&c>=48)==true)){if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
    token=3;
    goto LB_10;
    LB_3:
    switch((c=mInput[mIndex++])<=101&&c>=46?_input_914903567[c-46]:0)
    {
      case 1:
      case 2:
        break;
      case 3:
        token=3;
        switch((c=mInput[mIndex++])<=101&&c>=46?_input__275241956[c-46]:0)
        {
          case 1:
          case 2:
            break;
          case 3:
            token=3;
            break;
          default:
            {if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
            break;
        }
        break;
      default:
        mIndex--;
        goto LB_0;
    }
    LB_5:
    switch((c=mInput[mIndex++])<=101&&c>=46?_input__275241956[c-46]:0)
    {
      case 1:
        goto LB_14;
      case 2:
        //8->9
        if(!(((c=mInput[mIndex++])<=57&&c>=48)==true)){if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
        token=3;
        //9->10
        if(!(((c=mInput[mIndex++])<=57&&c>=48)==true)){if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
        token=3;
        break;
      case 3:
        token=3;
        switch((c=mInput[mIndex++])<=101&&c>=46?_input_914903567[c-46]:0)
        {
          case 1:
          case 2:
            goto LB_5;
          case 3:
            token=3;
            switch((c=mInput[mIndex++])<=101&&c>=46?_input__275241956[c-46]:0)
            {
              case 1:
              case 2:
                goto LB_5;
              case 3:
                token=3;
                goto LB_5;
              default:
                {if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
                break;
            }
            break;
          default:
            {if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
            break;
        }
        break;
      default:
        mIndex--;
        goto LB_0;
    }
    LB_10:
    switch((c=mInput[mIndex++])<=101&&c>=48?_input__1363445837[c-48]:0)
    {
      case 1:
        goto LB_14;
      case 2:
        token=3;
        goto LB_11;
      default:
        mIndex--;
        goto LB_0;
    }
    LB_15:
    switch((c=mInput[mIndex++])<=57&&c>=46?_input__1626705557[c-46]:0)
    {
      case 1:
        token=4;
        goto LB_15;
      case 2:
        //16->17
        if(!(((c=mInput[mIndex++])<=57&&c>=48)==true)){if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
        token=4;
        goto LB_17;
      default:
        mIndex--;
        goto LB_0;
    }
    LB_11:
    switch((c=mInput[mIndex++])<=101&&c>=48?_input__1363445837[c-48]:0)
    {
      case 1:
        goto LB_14;
      case 2:
        token=3;
        switch((c=mInput[mIndex++])<=101&&c>=48?_input__1363445837[c-48]:0)
        {
          case 1:
            goto LB_11;
          case 2:
            token=3;
            switch((c=mInput[mIndex++])<=101&&c>=48?_input__1363445837[c-48]:0)
            {
              case 1:
                goto LB_11;
              case 2:
                token=3;
                goto LB_11;
              default:
                {if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
                break;
            }
            break;
          default:
            {if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
            break;
        }
        break;
      default:
        mIndex--;
        goto LB_0;
    }
    LB_17:
    //17->17
    if(!(((c=mInput[mIndex++])<=57&&c>=48)==true)){if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
    token=4;
    goto LB_17;
    LB_0:
    if(token!=0&&add)
    {
      OnMatch(startIndex,mIndex,token);
    }
    match=new Match(token,startIndex,mIndex);
    return match;
  }
  #endregion
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  protected unsafe virtual void Skip()
  {
    ushort token=0,c=0;
    int startIndex=mIndex;
    switch((c=mInput[mIndex++])<=47&&c>=9?_input__58397204[c-9]:0)
    {
      case 1:
        token=12;
        break;
      case 2:
        switch((c=mInput[mIndex++])<=47&&c>=42?_input_119682859[c-42]:0)
        {
          case 1:
            goto LB_4;
          case 2:
            token=13;
            goto LB_3;
          default:
            {if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
            break;
        }
        break;
      default:
        {if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
        break;
    }
    LB_6:
    //6->6
    if(!(((c=mInput[mIndex++])<=32&&c>=9?_input__1675836692[c-9]:0)!=0)){if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
    token=12;
    goto LB_6;
    LB_4:
    switch((c=mInput[mIndex++])<=42?_input_548224306[c]:2)
    {
      case 1:
        switch((c=mInput[mIndex++])<=47?_input__1223601924[c]:1)
        {
          case 1:
            goto LB_4;
          case 2:
            token=14;
            goto LB_0;
          default:
            {if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
            break;
        }
        break;
      case 2:
        goto LB_4;
      default:
        mIndex--;
        goto LB_0;
    }
    LB_3:
    //3->3
    if(!(((c=mInput[mIndex++])<=10?_input_490290302[c]:1)!=0)){if(token==0)mIndex=startIndex;else mIndex--;goto LB_0;}
    token=13;
    goto LB_3;
    LB_0:
    if(token!=0)
    {
      OnMatch(startIndex,mIndex,token);
    }
    if(token!=0)
    {
      Skip();
    }
  }
  public int GetMatchTag(ushort token) => __tags.ContainsKey(token)?__tags[token]:-1;
  public string GetMatchName(ushort token)
  {
    switch(token)
    {
      case 2:
        return "ID";
      case 3:
        return "NUMBER";
      case 4:
        return "SCIENTIFIC";
      case 6:
        return "UNICODE";
      case 7:
        return "HEX";
      case 8:
        return "LITERAL";
      case 9:
        return "NULL";
      case 10:
        return "TRUE";
      case 11:
        return "FALSE";
      case 12:
        return "Skip";
      case 13:
        return "Skip";
      case 14:
        return "Skip";
      case 15:
        return "=";
      case 16:
        return "schema";
      case 17:
        return "{";
      case 18:
        return "bool";
      case 19:
        return "string";
      case 20:
        return "number";
      case 21:
        return "}";
      case 22:
        return ":";
      case 23:
        return ",";
      case 24:
        return "[";
      case 25:
        return "]";
      default:
        return $"字典中不包含Token为'{token}'的令牌。";
    }
  }
  public bool IsSkipMatch(ushort token)
  {
    switch(token)
    {
      case 2:
        return false;
      case 3:
        return false;
      case 4:
        return false;
      case 6:
        return false;
      case 7:
        return false;
      case 8:
        return false;
      case 9:
        return false;
      case 10:
        return false;
      case 11:
        return false;
      case 12:
        return true;
      case 13:
        return true;
      case 14:
        return true;
      case 15:
        return false;
      case 16:
        return false;
      case 17:
        return false;
      case 18:
        return false;
      case 19:
        return false;
      case 20:
        return false;
      case 21:
        return false;
      case 22:
        return false;
      case 23:
        return false;
      case 24:
        return false;
      case 25:
        return false;
      default:
        return false;
    }
  }
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  protected unsafe virtual Jsonpp parse(char* input,int length)
  {
    mIndex=0;
    mInput=input;
    mLength=length;
    Jsonpp result=default;
    //1->2
    result=Jsonpp();
    LB_0:
    return result;
  }
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  protected unsafe virtual Jsonpp Jsonpp(Match readStep=default)
  {
    JsonppExts loc_10_0=default;
    JsonppItem loc_21_0=default;
    Jsonpp result=default;
    //3->4
    loc_10_0=Jsonpp_ext(readStep);
    //4->5
    loc_21_0=Jsonpp_item();
    result=new Jsonpp(loc_10_0, loc_21_0)		;
    LB_0:
    return result;
  }
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  protected unsafe virtual JsonppItem Jsonpp_item(Match readStep=default)
  {
    Match loc_1_0=default;
    JsonppArray loc_20_0=default,loc_19_0=default;
    JsonppObject loc_16_0=default;
    JsonppItem result=default;
    switch(readStep=loc_1_0=loc_1_0=(readStep=readStep!=0?readStep:Match(false)))
    {
      case 8:
        result=new JsonppString(ParseString(loc_1_0, mInput), mInput, this);
        break;
      case 7:
        result=new JsonppHex(loc_1_0, mInput, this);
        break;
      case 6:
        result=new JsonppUnicode(loc_1_0, mInput, this);
        break;
      case 4:
        result=new JsonppScientific(loc_1_0, mInput, this);
        break;
      case 3:
        result=new JsonppNumber(loc_1_0, mInput, this);
        break;
      case 11:
        result=new JsonppFalse(loc_1_0, this);
        break;
      case 10:
        result=new JsonppTrue(loc_1_0, this);
        break;
      case 2:
        //8->9
        if(!((readStep=Match(false))==17)){ReportError(readStep.SourceSpan,$"{GetMessage("应输入")} '{{'");goto LB_0;}
        //9->10
        loc_20_0=Jsonpp_array_items();
        //10->7
        if(!((readStep=Match(false))==21)){ReportError(readStep.SourceSpan,$"{GetMessage("应输入")} '}}'");goto LB_0;}
        result=new JsonppSchemaObject(loc_1_0, loc_20_0, mInput, this);
        break;
      case 24:
        //15->16
        loc_19_0=Jsonpp_array_items();
        //16->7
        if(!((readStep=Match(false))==25)){ReportError(readStep.SourceSpan,$"{GetMessage("应输入")} ']'");goto LB_0;}
        result=loc_19_0;
        break;
      case 17:
        //17->18
        loc_16_0=Jsonpp_object_items();
        //18->7
        if(!((readStep=Match(false))==21)){ReportError(readStep.SourceSpan,$"{GetMessage("应输入")} '}}'");goto LB_0;}
        result=loc_16_0;
        loc_16_0.Finish(this);
        break;
      case 9:
        result=new JsonppNull(loc_1_0, this);
        break;
      default:
        {ReportError(readStep.SourceSpan,$"{GetMessage("应输入")} 'null'");goto LB_0;}
        break;
    }
    LB_0:
    return result;
  }
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  protected unsafe virtual JsonppArray Jsonpp_array_items(Match readStep=default)
  {
    JsonppArray loc_18_0=default,result=default;
    JsonppItem loc_12_0=default,loc_17_0=default;
    switch(readStep=readStep!=0?readStep:Match(false))
    {
      case 2:
      case 3:
      case 4:
      case 6:
      case 7:
      case 8:
      case 9:
      case 10:
      case 11:
      case 17:
      case 24:
        //11->12
        loc_17_0=Jsonpp_item(readStep);
        result=loc_18_0=new JsonppArray(loc_17_0);
        break;
      default:
        Back(readStep,_R_mIndex,ref mIndex);
        //11->12
        result=loc_18_0=new JsonppArray();
        break;
    }
    LB_12:
    switch(readStep=Match(false))
    {
      case 23:
        //14->12
        loc_12_0=Jsonpp_item();
        result=loc_18_0=loc_18_0.Add(loc_12_0);
        goto LB_12;
      default:
        Back(readStep,_R_mIndex,ref mIndex);
        goto LB_0;
    }
    LB_0:
    return result;
  }
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  protected unsafe virtual JsonppObject Jsonpp_object_items(Match readStep=default)
  {
    JsonppObjectItem loc_13_0=default,loc_15_0=default;
    JsonppObject loc_14_0=default,result=default;
    switch(readStep=readStep!=0?readStep:Match(false))
    {
      case 2:
      case 8:
        //19->20
        loc_13_0=Jsonpp_object_item(readStep);
        result=loc_14_0=new JsonppObject(loc_13_0);
        break;
      default:
        Back(readStep,_R_mIndex,ref mIndex);
        //19->20
        result=loc_14_0=new JsonppObject();
        break;
    }
    LB_20:
    switch(readStep=Match(false))
    {
      case 23:
        //22->20
        loc_15_0=Jsonpp_object_item();
        result=loc_14_0=loc_14_0.Add(loc_15_0);
        goto LB_20;
      default:
        Back(readStep,_R_mIndex,ref mIndex);
        goto LB_0;
    }
    LB_0:
    return result;
  }
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  protected unsafe virtual JsonppObjectItem Jsonpp_object_item(Match readStep=default)
  {
    Match loc_1_0=default;
    JsonppItem loc_12_0=default;
    JsonppObjectItem result=default;
    switch(loc_1_0=(readStep=readStep!=0?readStep:Match(false)))
    {
      case 8:
        //24->25
        if(!((readStep=Match(false))==22)){ReportError(readStep.SourceSpan,$"{GetMessage("应输入")} ':'");goto LB_0;}
        //25->26
        loc_12_0=Jsonpp_item();
        result=new JsonppObjectFieldItem(ParseString(loc_1_0, mInput), loc_12_0, mInput, this);
        break;
      case 2:
        //27->28
        if(!((readStep=Match(false))==22)){ReportError(readStep.SourceSpan,$"{GetMessage("应输入")} ':'");goto LB_0;}
        //28->26
        loc_12_0=Jsonpp_item();
        result=new JsonppObjectAlisaItem(loc_1_0, loc_12_0, mInput, this);
        break;
      default:
        {ReportError(readStep.SourceSpan,$"{GetMessage("应输入")} 'ID'");goto LB_0;}
        break;
    }
    LB_0:
    return result;
  }
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  protected unsafe virtual JsonppExts Jsonpp_ext(Match readStep=default)
  {
    JsonppExt loc_9_0=default,loc_11_0=default;
    JsonppExts loc_10_0=default,result=default;
    switch(readStep=readStep!=0?readStep:Match(false))
    {
      case 2:
      case 16:
        //29->30
        loc_9_0=Jsonpp_pp(readStep);
        result=loc_10_0=new JsonppExts(loc_9_0);
        break;
      default:
        Back(readStep,_R_mIndex,ref mIndex);
        //29->30
        result=loc_10_0=new JsonppExts();
        break;
    }
    LB_30:
    switch(readStep=Match(false))
    {
      case 2:
      case 16:
        //30->30
        loc_11_0=Jsonpp_pp(readStep);
        result=loc_10_0=loc_10_0.Add(loc_11_0);
        goto LB_30;
      default:
        Back(readStep,_R_mIndex,ref mIndex);
        goto LB_0;
    }
    LB_0:
    return result;
  }
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  protected unsafe virtual JsonppExt Jsonpp_pp(Match readStep=default)
  {
    Match loc_1_0=default,loc_2_0=default,loc_4_0=default;
    JsonppSchemaItems loc_8_0=default;
    JsonppExt result=default;
    switch(loc_1_0=readStep=loc_1_0=(readStep=readStep!=0?readStep:Match(false)))
    {
      case 16:
        //32->33
        if(!((loc_4_0=(readStep=Match(false)))==2)){ReportError(readStep.SourceSpan,$"{GetMessage("应输入")} 'ID'");goto LB_0;}
        //33->34
        if(!((readStep=Match(false))==17)){ReportError(readStep.SourceSpan,$"{GetMessage("应输入")} '{{'");goto LB_0;}
        //34->35
        loc_8_0=Jsonpp_schema_items();
        //35->36
        if(!((readStep=Match(false))==21)){ReportError(readStep.SourceSpan,$"{GetMessage("应输入")} '}}'");goto LB_0;}
        result=new JsonppSchema(loc_4_0, loc_8_0, mInput, this);
        break;
      case 2:
        //45->46
        if(!((readStep=Match(false))==15)){ReportError(readStep.SourceSpan,$"{GetMessage("应输入")} '='");goto LB_0;}
        //46->36
        if(!((loc_2_0=(readStep=Match(false)))==8)){ReportError(readStep.SourceSpan,$"{GetMessage("应输入")} '\"'");goto LB_0;}result=new JsonppDefineAlisa(loc_1_0, ParseString(loc_2_0, mInput), mInput, this);
        break;
      default:
        {ReportError(readStep.SourceSpan,$"{GetMessage("应输入")} 'ID'");goto LB_0;}
        break;
    }
    LB_0:
    return result;
  }
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  protected unsafe virtual JsonppSchemaItems Jsonpp_schema_items(Match readStep=default)
  {
    JsonppSchemaItem loc_5_0=default,loc_7_0=default;
    JsonppSchemaItems loc_6_0=default,result=default;
    //37->38
    loc_5_0=Jsonpp_schema_item(readStep);
    result=loc_6_0=new JsonppSchemaItems(loc_5_0);
    LB_38:
    switch(readStep=Match(false))
    {
      case 2:
      case 18:
      case 19:
      case 20:
        //38->38
        loc_7_0=Jsonpp_schema_item(readStep);
        result=loc_6_0=loc_6_0.Add(loc_7_0);
        goto LB_38;
      default:
        Back(readStep,_R_mIndex,ref mIndex);
        goto LB_0;
    }
    LB_0:
    return result;
  }
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  protected unsafe virtual JsonppSchemaItem Jsonpp_schema_item(Match readStep=default)
  {
    DuckTyping loc_3_0=default;
    Match loc_4_0=default;
    JsonppSchemaItem result=default;
    //39->40
    loc_3_0=Jsonpp_schema_item_type(readStep);
    switch(loc_4_0=(readStep=Match(false)))
    {
      case 2:
        result=new JsonppUsingAlisa(loc_3_0, loc_4_0, mInput, this);
        break;
      case 8:
        result=new JsonppSchemaField(loc_3_0, ParseString(loc_4_0, mInput), mInput, this);
        break;
      default:
        {ReportError(readStep.SourceSpan,$"{GetMessage("应输入")} '\"'");goto LB_0;}break;
        }
        LB_0:
        return result;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected unsafe virtual DuckTyping Jsonpp_schema_item_type(Match readStep=default)
    {
      Match loc_1_0=default;
      DuckTyping result=default;
      switch(readStep=loc_1_0=readStep=readStep!=0?readStep:Match(false))
      {
        case 2:
          result=GetDuckTypeing(loc_1_0, mInput);
          break;
        case 20:
          result=DuckTyping.Number;
          break;
        case 19:
          result=DuckTyping.String;
          break;
        case 18:
          result=DuckTyping.Bool;
          break;
        default:
          {ReportError(readStep.SourceSpan,$"{GetMessage("应输入")} 'bool'");goto LB_0;}
          break;
      }
      LB_0:
      return result;
    }
  }